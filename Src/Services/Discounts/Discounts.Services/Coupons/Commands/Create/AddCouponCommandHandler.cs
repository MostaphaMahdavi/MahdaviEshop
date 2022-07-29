using System;
using System.Threading;
using System.Threading.Tasks;
using Discounts.Domain.Coupons.Entities;
using Discounts.Domain.UnitOfWorks;
using MediatR;

namespace Discounts.Services.Coupons.Commands.Create
{
    public class AddCouponCommandHandler:IRequestHandler<AddCouponCommand,long>
    {
       private readonly ICouponCommandUnitOfWork _commandUnitOfWork;

        public AddCouponCommandHandler(ICouponCommandUnitOfWork commandUnitOfWork)
        {
            _commandUnitOfWork = commandUnitOfWork;
        }

        public async Task<long> Handle(AddCouponCommand request, CancellationToken cancellationToken)
        {
            Coupon coupon = Coupon.Create(request.ProductId,request.ProductTitle,request.DiscountType==0?1:request.DiscountType,request.Value,request.StartDate,request.EndDate);
            await _commandUnitOfWork.couponCommandRepository.AddAsync(coupon);
            await _commandUnitOfWork.SaveAsync();
            return coupon.Id;
        }
    }
}
