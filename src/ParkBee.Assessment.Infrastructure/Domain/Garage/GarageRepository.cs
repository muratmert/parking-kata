using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.Domain.Garages;
using ParkBee.Assessment.Infrastructure.Database;

namespace ParkBee.Assessment.Infrastructure.Domain.Garage
{
    public class GarageRepository : IGarageRepository
    {
        private readonly ApplicationDbContext _context;

        public GarageRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public async Task<Assessment.Domain.Garages.Garage> GetGarageById(int garageId)
        {
            return await _context.Garages.FirstOrDefaultAsync(g => g.Id.Equals(garageId));
        }
    }
}