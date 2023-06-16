using System.Threading;
using System.Threading.Tasks;
using ParkBee.Assessment.API.Controllers;
using ParkBee.Assessment.Application.Configuration.Queries;
using ParkBee.Asssessment.Domain.Users;

namespace ParkBee.Assessment.Application.Users
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        { 
            var user = await _userRepository.GetUserById(request.UserId);
            
            if (user == null)
            {
                throw new UserNotFoundException($"specified user could not find: {request.UserId}");
            }

            return new UserDto
            {
                Id = user.Id.Value,
                Name = user.Name,
                Email = user.Name,
                GarageId = user.GarageId
            };
        }
    }
}