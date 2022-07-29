using LoggingServices.Domains.Loggings.Entities;
using LoggingServices.Domains.Loggings.Repositories;
using MediatR;

namespace LoggingServices.Services.Loggings.Commands.Update
{
    public class UpdateLogDataCommandHandler : IRequestHandler<UpdateLogDataCommand,bool>
    {
        ILogRepository _logRepository;
        public UpdateLogDataCommandHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<bool> Handle(UpdateLogDataCommand request, CancellationToken cancellationToken)
        {
            var logInfo = LogData.Create(request.ControllerName, request.ActionName, request.LogLevel, request.Message);
            logInfo.Id = request.Id;
            await _logRepository.UpdateLogAsync(logInfo);
            return true;
        }
    }
}

