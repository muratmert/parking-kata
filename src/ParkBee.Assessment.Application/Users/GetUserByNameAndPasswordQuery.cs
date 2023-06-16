using ParkBee.Assessment.API.Controllers;
using ParkBee.Assessment.Application.Configuration.Queries;

namespace ParkBee.Assessment.Application.Users
{
    public class GetUserByNameAndPasswordQuery : IQuery<UserDto>
    {
        public GetUserByNameAndPasswordQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
        
        public string Username { get;  }

        public string Password { get;  }
    }
}