using System;
using Discounts.Domain.Coupons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discounts.DataAccessLayer.Coupons.Configs
{
    public class CouponConfig : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(c => c.ProductId).IsRequired();
            builder.Property(c=>c.ProductTitle).HasMaxLength(300);
            builder.Property(c=>c.DiscountType).IsRequired();
            builder.Property(C=>C.Value).IsRequired().HasMaxLength(3);
        }
    }
}
