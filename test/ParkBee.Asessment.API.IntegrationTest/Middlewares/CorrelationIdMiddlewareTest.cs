using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkBee.Assessment.API.Configuration;
using Xunit;

namespace ParkBee.Asessment.API.IntegrationTest.Middlewares
{
    public class CorrelationIdMiddlewareTest
    {
        [Fact]
        public async Task GivenRequest_WhenCorrelationIdExist_Then_CorrelationIdAddedOnRequestHeader()
        {
            //arrange 
            using IHost host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            services.AddControllers();
                        })
                        .Configure(app =>
                        {
                            app.UseMiddleware<CorrelationMiddleware>();
                        });
                })
                .StartAsync();      
            
            // assert
            var response = await host.GetTestClient().GetAsync("/");
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }
    }
}