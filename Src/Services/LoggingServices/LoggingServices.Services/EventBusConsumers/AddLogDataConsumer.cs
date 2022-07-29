using System;
using EventBus.Messages.Events;
using LoggingServices.Services.Loggings.Commands.Create;
using MassTransit;
using MediatR;

namespace LoggingServices.Services.EventBusConsumers
{
    public class AddLogDataConsumer:IConsumer<AddLogDataEvent>
    {
        private readonly IMediator _mediatR;
        public AddLogDataConsumer(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task Consume(ConsumeContext<AddLogDataEvent> context)
        {
            AddLogDataCommand couponCommand = new AddLogDataCommand
            {
               ControllerName=context.Message.ControllerName,
               ActionName=context.Message.ActionName,
             LogLevel=context.Message.LogLevel,
             Message=context.Message.Message

            };

          await _mediatR.Send(couponCommand);
        }
    }
}

