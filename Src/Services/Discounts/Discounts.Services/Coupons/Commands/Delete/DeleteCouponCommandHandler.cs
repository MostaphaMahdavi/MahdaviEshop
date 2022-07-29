using System;
using System.Threading;
using System.Threading.Tasks;
using Discounts.Domain.Coupons.Entities;
using Discounts.Domain.UnitOfWorks;
using MediatR;

namespace Discounts.Services.Coupons.Commands.Delete
{
    public class DeleteCouponCommandHandler:IRequestHandler<DeleteCouponCommand,bool>
    {
       private readonly ICouponCommandUnitOfWork _couponCommandUnitOfWork;
       private readonly ICouponQueryUnitOfWork _couponQueryUnitOfWork;

        public DeleteCouponCommandHandler(ICouponCommandUnitOfWork couponCommandUnitOfWork, ICouponQueryUnitOfWork couponQueryUnitOfWork)
        {
            _couponCommandUnitOfWork = couponCommandUnitOfWork;
            _couponQueryUnitOfWork = couponQueryUnitOfWork;
        }


        public async Task<bool> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            Coupon coupon = await _couponQueryUnitOfWork.couponQueryRepository.GetByIdAsync(request.Id);
            if (coupon is null )
            {
                return false;
            }
             _couponCommandUnitOfWork.couponCommandRepository.Delete(coupon);
            await _couponCommandUnitOfWork.SaveAsync();
            return true;
        }
    }
}
