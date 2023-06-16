using System.Threading.Tasks;

namespace ParkBee.Assessment.Domain.Garages
{
    public interface IDoorHistoryRepository
    {
        Task AddDoorHistory(DoorHistory doorHistory);
    }
}