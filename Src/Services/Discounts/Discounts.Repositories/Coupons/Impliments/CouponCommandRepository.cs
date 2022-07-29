using System;
using System.Threading.Tasks;
using Discounts.DataAccessLayer.Context;
using Discounts.Domain.Coupons.Entities;
using Discounts.Domain.Coupons.Repositories;

namespace Discounts.Repositories.Coupons.Impliments
{
    public class CouponCommandRepository: ICouponCommandRepository
    {
       private readonly CouponContext _db;
        public CouponCommandRepository(CouponContext db)
        {
            _db = db;
        }

        public async Task<Coupon> AddAsync(Coupon coupon)
        {
            await _db.Coupons.AddAsync(coupon);
            return coupon;
        }

        public bool Delete(Coupon coupon)
        {
            _db.Coupons.Remove(coupon);
            return true;

        }

        public Coupon Update(Coupon coupon)
        {
            _db.Coupons.Update(coupon);
            return coupon;
        }
    }

}
