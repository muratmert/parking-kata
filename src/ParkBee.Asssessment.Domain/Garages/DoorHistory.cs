using System;
using ParkBee.Asssessment.Domain;

namespace ParkBee.Assessment.Domain.Garages
{
    public class DoorHistory : Entity
    {
        public int HistoryId { get; }
        
        public int DoorId { get;  }
        
        public bool Status { get;  }

        public DateTime CreatedDateTime { get; }

        public DoorHistory(int doorId,bool status)
        {
            DoorId = doorId;
            Status = status;
            CreatedDateTime = DateTime.UtcNow;
        }
    }
}