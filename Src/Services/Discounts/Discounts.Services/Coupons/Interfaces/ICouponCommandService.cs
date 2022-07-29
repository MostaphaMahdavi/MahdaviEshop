using System;
using System.Threading.Tasks;
using Discounts.Domain.Coupons.Dtos;

namespace Discounts.Services.Coupons.Interfaces
{
    public interface ICouponCommandService
    {
        Task<int> AddCouponAsync(AddCouponInfo addCouponInfo);
        Task<int> UpdateCouponAsync(UpdateCouponInfo updateCouponInfo);
        Task<bool> DeleteCouponAsync(DeleteCouponInfo deleteCouponInfo);
    }
}
