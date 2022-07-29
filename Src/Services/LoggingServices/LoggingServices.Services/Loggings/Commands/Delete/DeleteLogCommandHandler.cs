using LoggingServices.Domains.Loggings.Repositories;
using MediatR;

namespace LoggingServices.Services.Loggings.Commands.Delete
{
    public class DeleteLogCommandHandler : IRequestHandler<DeleteLogCommand, bool>
    {
        ILogRepository _logRepository;
        public DeleteLogCommandHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<bool> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
        {
            await _logRepository.DeleteLogAsync(request.Id);
            return true;
        }
    }
}

