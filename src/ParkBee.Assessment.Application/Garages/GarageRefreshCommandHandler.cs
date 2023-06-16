using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using ParkBee.Assessment.Application.Configuration.Commands;
using ParkBee.Assessment.Domain.Garages;

namespace ParkBee.Assessment.Application.Garages
{
    public class GarageRefreshCommandHandler : ICommandHandler<GarageRefreshCommand, List<GarageDto>>
    {
        private readonly IGarageRepository _garageRepository;

        public GarageRefreshCommandHandler(IGarageRepository garageRepository)
        {
            _garageRepository = garageRepository;
        }
        
        public async Task<List<GarageDto>> Handle(GarageRefreshCommand command, CancellationToken cancellationToken)
        {
            Garage garage = await _garageRepository.GetGarageById(command.GarageId);
            
            if (garage == null)
            {
                throw new GarageNotFoundException("Garage could not find");
            }
            
            foreach (Door garageDoor in garage.Doors)
            {
                int retryCount = 0;
                Ping ping = new Ping();
                PingReply reply = null;
                while (retryCount<2)
                {
                    try
                    {
                        reply = ping.Send(garageDoor.IpAddress, 1000);
                        if (reply.Status == IPStatus.Success)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        retryCount++;
                    }
                }

                if (!garageDoor.Status && reply.Status == IPStatus.Success)
                {
                    garageDoor.ChangeDoorStatusAsHealthy();
                }
            }
            
            return garage.Doors.Select(g=> new GarageDto
            {
                Id = command.GarageId,
                Name = garage.Name,
                IpAddress = g.IpAddress,
                Status = g.Status,
                DoorId = g.Id
            }).ToList();
            
        }
    }
}