using System;
using Discounts.Domain.Coupons.Dtos;
using MediatR;

namespace Discounts.Services.Coupons.Commands.Update
{
    public class UpdateCouponCommand:UpdateCouponInfo,IRequest<CouponInfo>
    {
        public UpdateCouponCommand()
        {
        }
    }
}
