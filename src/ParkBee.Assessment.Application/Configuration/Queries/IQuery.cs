using MediatR;

namespace ParkBee.Assessment.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        
    }
}