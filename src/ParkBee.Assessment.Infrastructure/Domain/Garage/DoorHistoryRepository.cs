using System.Threading.Tasks;
using ParkBee.Assessment.Domain.Garages;
using ParkBee.Assessment.Infrastructure.Database;

namespace ParkBee.Assessment.Infrastructure.Domain.Garage
{
    public class DoorHistoryRepository : IDoorHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public DoorHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDoorHistory(DoorHistory doorHistory)
        {
            await _context.History.AddAsync(doorHistory);
        }
    }
}