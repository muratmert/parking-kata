using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ParkBee.Assessment.API.Configuration
{
    public class CorrelationMiddleware
    {
        internal const string CorrelationHeaderKey = "CorrelationId";
        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            Guid correlationId = Guid.NewGuid();
            context.Request?.Headers.Add(CorrelationHeaderKey, correlationId.ToString());
            await _next.Invoke(context);
        }
        
    }
}