using System.Collections.Generic;
using System.Threading.Tasks;
using Discounts.Domain.Coupons.Dtos;

namespace Discounts.Services.Coupons.Interfaces
{
    public interface ICouponQueryService
    {
        Task<IList<CouponInfo>> GetAllCouponAsync();
        Task<CouponInfo> GetCouponByIdAsync(int couponId);
    }
}
