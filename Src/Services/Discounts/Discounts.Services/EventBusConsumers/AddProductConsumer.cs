using System;
using AutoMapper;
using EventBus.Messages.Events;
using MediatR;
using MassTransit;
using System.Threading.Tasks;
using Discounts.Services.Coupons.Commands.Create;
using Discounts.Domain.Coupons.Enums;

namespace Discounts.Services.EventBusConsumers
{
    public class AddProductConsumer : IConsumer<AddedProductEvent>
    {
       private readonly IMediator _mediatR;
        public AddProductConsumer(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task Consume(ConsumeContext<AddedProductEvent> context)
        {
            AddCouponCommand couponCommand = new AddCouponCommand
            {
                ProductId = context.Message.ProductId,
                ProductTitle = context.Message.ProductTitle
         
            };

            await _mediatR.Send(couponCommand);
        }
    }
}
