using System.Collections.Generic;
using System.Linq;
using ParkBee.Assessment.Domain.Garages.Events;
using ParkBee.Asssessment.Domain;

namespace ParkBee.Assessment.Domain.Garages
{
    public class Garage : Entity, IAggregateRoot
    {
        public int Id { get; }
        
        public string Name { get;  }
        
        public string Address { get;  }
        
        public ICollection<Door> Doors { get; }

        public Garage(string name,string address)
        {
            Name = name;
            Address = address;
            Doors = new List<Door>();
        }

        public void AddDoor(Door door)
        {
            Doors.Add(door);
        }
    }
}