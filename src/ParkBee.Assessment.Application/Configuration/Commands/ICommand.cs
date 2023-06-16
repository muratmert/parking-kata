using System;
using MediatR;

namespace ParkBee.Assessment.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {
        Guid Id { get; }
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}