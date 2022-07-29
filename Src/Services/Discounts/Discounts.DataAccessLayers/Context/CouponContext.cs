using System;
using Discounts.DataAccessLayer.Coupons.Configs;
using Discounts.Domain.Coupons.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discounts.DataAccessLayer.Context
{
    public class CouponContext:DbContext
    {
        public CouponContext(DbContextOptions<CouponContext> options):base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CouponConfig).Assembly);
        }
    }
}
