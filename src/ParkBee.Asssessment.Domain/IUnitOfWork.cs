using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Asssessment.Domain
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}