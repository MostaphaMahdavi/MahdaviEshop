using System;
using LoggingServices.Domains.Loggings.Entities;
using MediatR;

namespace LoggingServices.Services.Loggings.Queries.Get
{
    public class GetLogByIdQuery:IRequest<LogData>
    {
        public string Id { get; set; }
        
    }
}

