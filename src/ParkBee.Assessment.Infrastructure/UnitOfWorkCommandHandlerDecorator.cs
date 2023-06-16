using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ParkBee.Assessment.Application.Configuration.Commands;
using ParkBee.Assessment.Infrastructure.Database;
using ParkBee.Asssessment.Domain;

namespace ParkBee.Assessment.Infrastructure
{
    public class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T:ICommand
    {
        private readonly ICommandHandler<T> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorated, IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _context = context;
        }
        
        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await _decorated.Handle(command, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}