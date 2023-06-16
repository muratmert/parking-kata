using System;
using MediatR;

namespace ParkBee.Asssessment.Domain
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}