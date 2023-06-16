using ParkBee.Asssessment.Domain;

namespace ParkBee.Assessment.Domain.Garages.Events
{
    public class DoorStatusChanged : DomainEventBase
    {
        public int DoorId { get; }

        public bool Status { get; }
        
        public DoorStatusChanged(int doorId,bool status)
        {
            DoorId = doorId;
            Status = status;
        }
    }
}