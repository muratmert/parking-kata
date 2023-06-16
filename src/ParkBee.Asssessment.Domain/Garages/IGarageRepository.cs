using System.Threading.Tasks;

namespace ParkBee.Assessment.Domain.Garages
{
    public interface IGarageRepository
    {
        Task<Garage> GetGarageById(int garageId);
    }
}