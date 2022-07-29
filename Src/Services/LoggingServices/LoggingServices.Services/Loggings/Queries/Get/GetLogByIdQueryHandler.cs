using LoggingServices.Domains.Loggings.Entities;
using LoggingServices.Domains.Loggings.Repositories;
using MediatR;

namespace LoggingServices.Services.Loggings.Queries.Get
{
    public class GetLogByIdQueryHandler : IRequestHandler<GetLogByIdQuery, LogData>
    {
        ILogRepository _logRepository;
        public GetLogByIdQueryHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<LogData> Handle(GetLogByIdQuery request, CancellationToken cancellationToken)=>        
            await _logRepository.GetByIdAsync(request.Id);
        
    }
}

