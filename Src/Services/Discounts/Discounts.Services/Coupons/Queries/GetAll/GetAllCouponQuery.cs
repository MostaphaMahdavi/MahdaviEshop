using System.Collections.Generic;
using Discounts.Domain.Coupons.Dtos;
using Discounts.Domain.UnitOfWorks;
using MediatR;

namespace Discounts.Services.Coupons.Queries.GetAll
{
    public class GetAllCouponQuery:IRequest<List<CouponInfo>>
    {   
        
    }
}
