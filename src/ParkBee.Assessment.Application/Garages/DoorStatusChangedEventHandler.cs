using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ParkBee.Assessment.Domain.Garages;
using ParkBee.Assessment.Domain.Garages.Events;

namespace ParkBee.Assessment.Application.Garages
{
    public class DoorStatusChangedEventHandler: INotificationHandler<DoorStatusChanged>
    {
        private readonly IDoorHistoryRepository _doorHistoryRepository;
        
        public DoorStatusChangedEventHandler(IDoorHistoryRepository doorHistoryRepository)
        {
            _doorHistoryRepository = doorHistoryRepository;
        }

        public async Task Handle(DoorStatusChanged @event, CancellationToken cancellationToken)
        {
            await _doorHistoryRepository.AddDoorHistory(new DoorHistory(@event.DoorId, @event.Status));
        }
    }
}