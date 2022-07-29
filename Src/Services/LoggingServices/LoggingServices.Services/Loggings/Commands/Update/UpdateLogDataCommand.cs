using System;
using LoggingServices.Domains.Loggings.Dtos;
using MediatR;

namespace LoggingServices.Services.Loggings.Commands.Update
{
    public class UpdateLogDataCommand: UpdateLogDataInfo,IRequest<bool>
    {
        
    }
}

