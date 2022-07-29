using System;
using System.Threading.Tasks;
using Discounts.Domain.Coupons.Repositories;

namespace Discounts.Domain.UnitOfWorks
{
    public interface ICouponCommandUnitOfWork
    {
        ICouponCommandRepository couponCommandRepository { get; }
        Task SaveAsync();
    }
}
