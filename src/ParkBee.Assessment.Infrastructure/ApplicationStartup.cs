using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;
using ParkBee.Assessment.Application.Configuration;
using ParkBee.Assessment.Infrastructure.Database;
using ParkBee.Assessment.Infrastructure.Domain;
using ParkBee.Assessment.Infrastructure.Logging;
using Serilog;

namespace ParkBee.Assessment.Infrastructure
{
    public class ApplicationStartup
    {
        public static IServiceProvider Initialize(IServiceCollection services, string connectionString, ILogger logger,
            IExecutionContextAccessor executionContextAccessor)
        {
            var serviceProvider =
                CreateAutofacServiceProvider(services, connectionString, logger, executionContextAccessor);

            return serviceProvider;
        }

        private static IServiceProvider CreateAutofacServiceProvider(IServiceCollection services,
            string connectionString, ILogger logger, IExecutionContextAccessor executionContextAccessor)
        {
            var container = new ContainerBuilder();

            container.Populate(services);

            container.RegisterModule(new LoggingModule(logger));
            container.RegisterModule(new DataAccessModule(connectionString));
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new DomainModule());
            container.RegisterModule(new ProcessingModule());
            container.RegisterInstance(executionContextAccessor);

            var buildContainer = container.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));

            var serviceProvider = new AutofacServiceProvider(buildContainer);

            CompositionRoot.SetContainer(buildContainer);

            return serviceProvider;
        }
    }
}