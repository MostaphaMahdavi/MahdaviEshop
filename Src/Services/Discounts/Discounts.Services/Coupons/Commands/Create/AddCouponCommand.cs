using System;
using Discounts.Domain.Coupons.Dtos;
using MediatR;

namespace Discounts.Services.Coupons.Commands.Create
{
    public class AddCouponCommand:AddCouponInfo, IRequest<long>
    {
        public AddCouponCommand()
        {
        }
    }
}
