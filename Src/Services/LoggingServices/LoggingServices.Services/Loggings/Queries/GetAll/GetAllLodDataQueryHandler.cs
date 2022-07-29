using LoggingServices.Domains.Loggings.Entities;
using LoggingServices.Domains.Loggings.Repositories;
using MediatR;

namespace LoggingServices.Services.Loggings.Queries.GetAll
{
    public class GetAllLodDataQueryHandler : IRequestHandler<GetAllLodDataQuery, List<LogData>>
    {
        ILogRepository _logRepository;
        public GetAllLodDataQueryHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<List<LogData>> Handle(GetAllLodDataQuery request, CancellationToken cancellationToken)=>        
            await _logRepository.GetAllAsync();
        
    }
}

