using System;
using MediatR;

namespace LoggingServices.Services.Loggings.Commands.Delete
{
    public class DeleteLogCommand:IRequest<bool>
    {
        public string Id { get; set; }
    }
}

