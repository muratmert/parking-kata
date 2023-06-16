using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ParkBee.Assessment.Application.Users;

namespace ParkBee.Assessment.API.Configuration
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public JwtTokenMiddleware(RequestDelegate next, IConfiguration configuration, IMediator mediator)
        {
            _next = next;
            _configuration = configuration;
            _mediator = mediator;
        }
        
        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecurityKey"]);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                    context.Items["User"] = await _mediator.Send(new GetUserByIdQuery(userId));
                }
                catch
                {
                    context.Response.StatusCode = 400;             
                    await context.Response.WriteAsync("UserId is missing");
                    return;
                }
            }
            await _next(context);
        }
    }
}