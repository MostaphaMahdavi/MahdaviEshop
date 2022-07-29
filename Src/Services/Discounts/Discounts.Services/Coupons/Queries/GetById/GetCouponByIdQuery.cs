using Discounts.Domain.Coupons.Dtos;
using MediatR;

namespace Discounts.Services.Coupons.Queries.GetById
{
    public class GetCouponByIdQuery:IRequest<CouponInfo>
    {
        public long Id { get; set; }
        public GetCouponByIdQuery()
        {
        }
    }
}
