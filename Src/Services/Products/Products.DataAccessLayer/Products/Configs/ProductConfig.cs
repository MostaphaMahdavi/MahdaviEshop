using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products.Entities;

namespace Products.DataAccessLayer.Products.Configs
{
    public class ProductConfig:IEntityTypeConfiguration<Product>
    {    
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(c=>c.Titile).IsRequired().HasMaxLength(250);
            builder.Property(c=>c.Description).IsRequired().HasMaxLength(5000);
            builder.Property(c => c.PermaLink).IsRequired().HasMaxLength(200).HasDefaultValue("http://www.google.com");
            builder.Property(c=>c.IsActive).HasDefaultValue(false);
            builder.Property(c=>c.CoverImageUrl).IsRequired().HasDefaultValue("https://via.placeholder.com/450x150");
            builder.Property(c=>c.Price).IsRequired().HasMaxLength(20);
            builder.Property(c=>c.Code).IsRequired().HasMaxLength(50);

            builder.HasOne(c=>c.Category).WithMany(c=>c.Products).HasForeignKey(c=>c.CategoryId);

            List<Product> products = new List<Product>();
            var pro001 = Product.Create("Title001", "Description001", false, "http://www.google.com",
                "https://via.placeholder.com/550x350", 1000, "Code110", 1);
            pro001.Id = 1;
            products.Add(pro001);
            var pro002 = Product.Create("Title002", "Description002", true, "http://www.yahoo.com",
               "https://via.placeholder.com/200x100", 205, "Code205", 1);
            pro002.Id = 2;
            products.Add(pro002);
            builder.HasData(products);

        }
    }
}
