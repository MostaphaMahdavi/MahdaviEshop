using System;
using System.Threading.Tasks;
using Discounts.Domain.Coupons.Entities;

namespace Discounts.Domain.Coupons.Repositories
{
    public interface ICouponCommandRepository
    {
        Task<Coupon> AddAsync(Coupon coupon);
        Coupon Update(Coupon coupon);
        bool Delete(Coupon coupon);
        
    }
}
