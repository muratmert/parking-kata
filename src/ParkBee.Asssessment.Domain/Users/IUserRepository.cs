using System;
using System.Threading.Tasks;

namespace ParkBee.Asssessment.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetUserByNameAndPassword(string name, string password);

        Task<User> GetUserById(Guid Id);
    }
}