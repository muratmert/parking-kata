using System.Threading;
using System.Threading.Tasks;
using ParkBee.Assessment.Application.Configuration.Commands;
using ParkBee.Assessment.Infrastructure.Database;
using ParkBee.Asssessment.Domain;

namespace ParkBee.Assessment.Infrastructure
{
    public class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public UnitOfWorkCommandHandlerWithResultDecorator(ICommandHandler<T, TResult> decorated, IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _context = context;
        }
        
        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await _decorated.Handle(command, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return result;
        }
    }
}