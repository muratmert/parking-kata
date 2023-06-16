using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.Infrastructure.Database;
using ParkBee.Asssessment.Domain.Users;

namespace ParkBee.Assessment.Infrastructure.Domain.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUserByNameAndPassword(string name, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Name.Equals(name) && u.Password.Equals(password));
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u=>Equals(u.Id, id));
        }
    }
}