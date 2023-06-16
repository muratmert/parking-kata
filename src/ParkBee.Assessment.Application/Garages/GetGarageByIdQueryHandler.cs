using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ParkBee.Assessment.Application.Configuration.Queries;
using ParkBee.Assessment.Domain.Garages;

namespace ParkBee.Assessment.Application.Garages
{
    public class GetGarageByIdQueryHandler : IQueryHandler<GetGarageByIdQuery,List<GarageDto>>
    {
        private readonly IGarageRepository _garageRepository;

        public GetGarageByIdQueryHandler(IGarageRepository garageRepository)
        {
            _garageRepository = garageRepository;
        }

        public async Task<List<GarageDto>> Handle(GetGarageByIdQuery query, CancellationToken cancellationToken)
        {
            Garage garage = await _garageRepository.GetGarageById(query.GarageId);

            if (garage == null)
            {
                throw new GarageNotFoundException("Garage could not find");
            }
            
            return garage.Doors.Select(g=> new GarageDto
            {
                Id = query.GarageId,
                Name = garage.Name,
                IpAddress = g.IpAddress,
                Status = g.Status,
                DoorId = g.Id
            }).ToList();
        }
    }
}