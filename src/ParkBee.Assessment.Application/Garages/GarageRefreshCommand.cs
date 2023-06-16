using System.Collections.Generic;
using ParkBee.Assessment.Application.Configuration.Commands;

namespace ParkBee.Assessment.Application.Garages
{
    public class GarageRefreshCommand : CommandBase<List<GarageDto>>
    {
        public GarageRefreshCommand(int garageId)
        {
            GarageId = garageId;
        }
        public int GarageId { get; }
    }
}