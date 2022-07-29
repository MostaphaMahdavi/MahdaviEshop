using Discounts.Domain.Coupons.Repositories;

namespace Discounts.Domain.UnitOfWorks
{
    public interface ICouponQueryUnitOfWork
    {
        ICouponQueryRepository couponQueryRepository { get; }
    }
}
