using System;
using Discounts.Domain.Coupons.Dtos;
using Discounts.Domain.UnitOfWorks;
using MediatR;

namespace Discounts.Services.Coupons.Commands.Delete
{
    public class DeleteCouponCommand:DeleteCouponInfo,IRequest<bool>
    {      
        public DeleteCouponCommand()
        {
        }
    }
}
