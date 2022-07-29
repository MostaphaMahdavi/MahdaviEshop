using System;
using Discounts.DataAccessLayer.Context;
using Discounts.Domain.Coupons.Repositories;
using Discounts.Domain.UnitOfWorks;
using Discounts.Repositories.Coupons.Impliments;

namespace Discounts.Repositories.UnitOfWorks
{
    public class CouponQueryUnitOfWork: ICouponQueryUnitOfWork
    {
        CouponContext _db;

        public CouponQueryUnitOfWork(CouponContext db)
        {
            _db = db;
        }

        private ICouponQueryRepository _couponQueryRepository;
        public ICouponQueryRepository couponQueryRepository {
            get
            {
                return _couponQueryRepository is null ? new CouponQueryRepository(_db) : _couponQueryRepository;
            }}
    }
}
