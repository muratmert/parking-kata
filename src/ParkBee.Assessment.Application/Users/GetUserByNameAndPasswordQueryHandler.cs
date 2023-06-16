using System.Threading;
using System.Threading.Tasks;
using ParkBee.Assessment.API.Controllers;
using ParkBee.Assessment.Application.Configuration.Queries;
using ParkBee.Asssessment.Domain.Users;

namespace ParkBee.Assessment.Application.Users
{
    public class GetUserByNameAndPasswordQueryHandler : IQueryHandler<GetUserByNameAndPasswordQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByNameAndPasswordQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByNameAndPasswordQuery query, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserByNameAndPassword(query.Username, query.Password);

            if (user == null)
            {
                throw new UserUnAuthorizedException("User Could Not Authenticate !");
            }

            return new UserDto
            {
                Id = user.Id.Value,
                Name = user.Name,
                Email = user.Email,
                GarageId = user.GarageId
            };
        }
    }
}