using Discounts.Domain.Coupons.Enums;
using MahdaviEshop.Framework.Entities;
using MahdaviEshop.Framework.Extensions;

namespace Discounts.Domain.Coupons.Entities
{
    public class Coupon:BaseEntity
    {
        private Coupon()
        {

        }
        public long ProductId { get;private set; }
        public string ProductTitle { get;private set; }
        public int DiscountType { get;private set; }
        public int Value { get;private set; }
        public DateTime StartDate { get;private set; }
        public DateTime EndDate { get;private set; }
       


        public static Coupon Create(long productId,string productTitle,int discountType,int value,
            DateTime startDate,DateTime endDate)
        {         
            return new Coupon
            {
                ProductId=productId,
                ProductTitle=productTitle,
                DiscountType= discountType,//.ToEnumString<DiscountType>(),
                Value=value,
                StartDate=startDate,
                EndDate=endDate
            };

        }

    }
}
