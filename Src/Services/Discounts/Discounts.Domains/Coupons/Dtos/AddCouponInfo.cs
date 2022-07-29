using System;
namespace Discounts.Domain.Coupons.Dtos
{
    public class AddCouponInfo
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int DiscountType { get; set; }
        public int Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}
