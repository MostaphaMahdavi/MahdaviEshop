using System.Collections.Generic;
using System.Threading.Tasks;
using Discounts.Domain.Coupons.Entities;

namespace Discounts.Domain.Coupons.Repositories
{
    public interface ICouponQueryRepository
    {
        Task<List<Coupon>> GetAllAsync();
        Task<Coupon> GetByIdAsync(long CouponId);

        Task<List<Coupon>> GetAllAsNoTrackingAsync();
        Task<Coupon> GetByIdAsNoTrackingAsync(long CouponId);
    }
}
