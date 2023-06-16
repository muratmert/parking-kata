using System.Threading.Tasks;

namespace ParkBee.Assessment.Infrastructure
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}