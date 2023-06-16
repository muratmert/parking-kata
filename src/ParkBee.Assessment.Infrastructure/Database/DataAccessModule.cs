using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.Application.Configuration.Data;
using ParkBee.Assessment.Domain.Garages;
using ParkBee.Assessment.Infrastructure.Domain;
using ParkBee.Assessment.Infrastructure.Domain.Users;
using ParkBee.Asssessment.Domain;
using ParkBee.Asssessment.Domain.Users;

namespace ParkBee.Assessment.Infrastructure.Database
{
    public class DataAccessModule : Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder =
                        new DbContextOptionsBuilder<ApplicationDbContext>();
                    dbContextOptionsBuilder.UseInMemoryDatabase("parkBee");
                    ApplicationDbContext context = new ApplicationDbContext(dbContextOptionsBuilder.Options);
                    context.Garages.AddRange(Enumerable.Range(1, 3).Select(s =>
                    {
                        Garage garage = new Garage($"Garage {s}", $"Address {s}");
                        garage.AddDoor(new Door("192.168.0.1",true));
                        garage.AddDoor(new Door("192.168.0.2",false));
                        return garage;
                    }));
                    context.SaveChanges();
                    return context;
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}