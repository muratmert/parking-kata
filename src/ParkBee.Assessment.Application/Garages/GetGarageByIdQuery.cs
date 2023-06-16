using System.Collections.Generic;
using ParkBee.Assessment.Application.Configuration.Queries;

namespace ParkBee.Assessment.Application.Garages
{
    public class GetGarageByIdQuery : IQuery<List<GarageDto>>
    {
        public GetGarageByIdQuery(int garageId)
        {
            GarageId = garageId;
        }
        public int GarageId { get; }
    }
}