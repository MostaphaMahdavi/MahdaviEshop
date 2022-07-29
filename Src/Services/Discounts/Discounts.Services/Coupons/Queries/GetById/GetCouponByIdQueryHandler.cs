using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Discounts.Domain.Coupons.Dtos;
using Discounts.Domain.Coupons.Entities;
using Discounts.Domain.UnitOfWorks;
using MediatR;

namespace Discounts.Services.Coupons.Queries.GetById
{
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, CouponInfo>
    {
       private readonly ICouponQueryUnitOfWork _couponQueryUnitOfWork;
       private readonly IMapper _mapper;

        public GetCouponByIdQueryHandler(ICouponQueryUnitOfWork couponQueryUnitOfWork,IMapper mapper)
        {
            _couponQueryUnitOfWork = couponQueryUnitOfWork;
            _mapper = mapper;
        }

        public async Task<CouponInfo> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            Coupon coupon = await _couponQueryUnitOfWork.couponQueryRepository.GetByIdAsNoTrackingAsync(request.Id);
            if (coupon is null)
            {
                throw new Exception("یافت نشد.");
            }
            return _mapper.Map<CouponInfo>(coupon);
        }
    }
}
