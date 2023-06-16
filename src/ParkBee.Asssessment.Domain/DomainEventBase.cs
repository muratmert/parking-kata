using System;

namespace ParkBee.Asssessment.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            this.OccurredOn = DateTime.Now;
        }
        
        public DateTime OccurredOn { get; }
    }
}