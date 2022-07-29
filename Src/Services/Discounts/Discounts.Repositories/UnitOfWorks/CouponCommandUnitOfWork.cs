using System;
using System.Threading.Tasks;
using Discounts.DataAccessLayer.Context;
using Discounts.Domain.Coupons.Repositories;
using Discounts.Domain.UnitOfWorks;
using Discounts.Repositories.Coupons.Impliments;

namespace Discounts.Repositories.UnitOfWorks
{
    public class CouponCommandUnitOfWork: ICouponCommandUnitOfWork
    {
        private readonly CouponContext _db;
        public CouponCommandUnitOfWork(CouponContext db)
        {
            _db = db;
        }

        private ICouponCommandRepository _couponCommandRepository;
        public ICouponCommandRepository couponCommandRepository
        {
            get { return _couponCommandRepository is null ? new CouponCommandRepository(_db) : _couponCommandRepository; }            
        }

        public async Task SaveAsync()=>
            await _db.SaveChangesAsync();
        
    }
}
