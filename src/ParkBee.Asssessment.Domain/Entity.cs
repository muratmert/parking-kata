using System.Collections.Generic;

namespace ParkBee.Asssessment.Domain
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents;
        
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();
        
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }
        
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}