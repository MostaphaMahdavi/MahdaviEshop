using System;
using LoggingServices.Domains.Loggings.Dtos;
using LoggingServices.Domains.Loggings.Entities;
using LoggingServices.Domains.Loggings.Repositories;
using MediatR;

namespace LoggingServices.Services.Loggings.Commands.Create
{
    public class AddLogDataCommand:LogDataInfo, IRequest<string>
    {
        
    }


    public class AddLogDataCommandHandler : IRequestHandler<AddLogDataCommand,string>
    {
        ILogRepository _logRepository;
        public AddLogDataCommandHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<string> Handle(AddLogDataCommand request, CancellationToken cancellationToken)
        {
            await _logRepository.CreateLogAsync(LogData.Create(request.ControllerName,request.ActionName,request.LogLevel,request.Message));
            return "ok";
        }

       
    }
}


