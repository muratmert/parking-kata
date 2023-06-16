using ParkBee.Assessment.Domain.Garages.Events;
using ParkBee.Asssessment.Domain;

namespace ParkBee.Assessment.Domain.Garages
{
    public class Door : Entity
    {
        public int Id { get;  }
        
        public string IpAddress { get;  }

        public bool Status { get; private set; }
        
        public Garage Garage { get;  }

        public Door(string ipAddress,bool status)
        {
            IpAddress = ipAddress;
            Status = status;
        }
        
        public void ChangeDoorStatusAsHealthy()
        {
            Status = true;
            AddDomainEvent(new DoorStatusChanged(Id,Status));
        }
    }
}