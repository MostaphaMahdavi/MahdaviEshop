using Microsoft.EntityFrameworkCore;
using Products.DataAccessLayer.Categories.Configs;
using Products.Domain.Categories.Entities;
using Products.Domain.Products.Entities;

namespace Products.DataAccessLayer.Context
{
    public class MahdaviContext:DbContext
    {
        public MahdaviContext(DbContextOptions<MahdaviContext> options):base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);            
        }

      
    }
}
