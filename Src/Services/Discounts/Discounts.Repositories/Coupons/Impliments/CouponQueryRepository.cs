using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discounts.DataAccessLayer.Context;
using Discounts.Domain.Coupons.Entities;
using Discounts.Domain.Coupons.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Discounts.Repositories.Coupons.Impliments
{
    public class CouponQueryRepository : ICouponQueryRepository
    {
      private readonly CouponContext _db;

        public CouponQueryRepository(CouponContext db)
        {
            _db = db;
        }        

        public async Task<List<Coupon>> GetAllAsync() =>
            await _db.Coupons.ToListAsync();        

        public async Task<Coupon> GetByIdAsync(long CouponId) =>
           await _db.Coupons.FirstOrDefaultAsync(c=>c.Id==CouponId);


        public async Task<List<Coupon>> GetAllAsNoTrackingAsync() =>
           await _db.Coupons.AsNoTracking().ToListAsync();

        public async Task<Coupon> GetByIdAsNoTrackingAsync(long CouponId) =>
            await _db.Coupons.AsNoTracking().FirstOrDefaultAsync(c => c.Id == CouponId);
    }

}
