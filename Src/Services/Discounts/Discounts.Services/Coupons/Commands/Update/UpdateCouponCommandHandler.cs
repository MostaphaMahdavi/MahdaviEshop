using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Discounts.Domain.Coupons.Dtos;
using Discounts.Domain.Coupons.Entities;
using Discounts.Domain.UnitOfWorks;
using MediatR;

namespace Discounts.Services.Coupons.Commands.Update
{
    public class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommand, CouponInfo>
    {
        private readonly ICouponCommandUnitOfWork _couponCommand;
        private readonly ICouponQueryUnitOfWork _couponQuery;
        private readonly IMapper _mapper;

        public UpdateCouponCommandHandler(ICouponCommandUnitOfWork couponCommand, ICouponQueryUnitOfWork couponQuery,IMapper mapper)
        {
            _couponCommand = couponCommand;
            _couponQuery = couponQuery;
            _mapper = mapper;
        }

        public async Task<CouponInfo> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            Coupon coupon = await _couponQuery.couponQueryRepository.GetByIdAsync(request.Id);
            if (coupon is null)
            {
                throw new Exception("یاقت نشد");
            }

            Coupon newCoupon = Coupon.Create(request.ProductId, request.ProductTitle, request.DiscountType, request.Value, request.StartDate, request.EndDate);

            _couponCommand.couponCommandRepository.Update(coupon);
            await _couponCommand.SaveAsync();
            return _mapper.Map<CouponInfo>(newCoupon);
        }
    }
}
