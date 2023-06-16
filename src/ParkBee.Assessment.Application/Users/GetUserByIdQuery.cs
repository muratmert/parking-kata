using System;
using ParkBee.Assessment.API.Controllers;
using ParkBee.Assessment.Application.Configuration.Queries;

namespace ParkBee.Assessment.Application.Users
{
    public class GetUserByIdQuery : IQuery<UserDto>
    {
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
        
        public Guid UserId { get; }
    }
}