using System;
using LoggingServices.Domains.Loggings.Entities;
using MediatR;

namespace LoggingServices.Services.Loggings.Queries.GetAll
{
    public class GetAllLodDataQuery:IRequest<List<LogData>>
    {
        
    }
}

