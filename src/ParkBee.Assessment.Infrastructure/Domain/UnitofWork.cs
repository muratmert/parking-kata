using System.Threading;
using System.Threading.Tasks;
using ParkBee.Assessment.Infrastructure.Database;
using ParkBee.Asssessment.Domain;

namespace ParkBee.Assessment.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}