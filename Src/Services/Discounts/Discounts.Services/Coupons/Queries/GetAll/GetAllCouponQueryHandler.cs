using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Discounts.Domain.Coupons.Dtos;
using Discounts.Domain.UnitOfWorks;
using MediatR;

namespace Discounts.Services.Coupons.Queries.GetAll
{
    public class GetAllCouponQueryHandler : IRequestHandler<GetAllCouponQuery, List<CouponInfo>>
    {
       private readonly ICouponQueryUnitOfWork _couponQUeryUnitOfWork;
       private readonly IMapper _mapper;

        public GetAllCouponQueryHandler(ICouponQueryUnitOfWork couponQUeryUnitOfWork,IMapper mapper)
        {
            _couponQUeryUnitOfWork = couponQUeryUnitOfWork;
            _mapper = mapper;
        }


        public async Task<List<CouponInfo>> Handle(GetAllCouponQuery request, CancellationToken cancellationToken)=>
         _mapper.Map<List<CouponInfo>>(await _couponQUeryUnitOfWork.couponQueryRepository.GetAllAsNoTrackingAsync());
        
        
    }
}
