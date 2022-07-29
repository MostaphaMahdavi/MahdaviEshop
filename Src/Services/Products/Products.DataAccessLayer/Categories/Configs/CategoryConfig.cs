using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Categories.Entities;

namespace Products.DataAccessLayer.Categories.Configs
{
    public class CategoryConfig:IEntityTypeConfiguration<Category>
    {
        
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c=>c.Title).IsRequired().HasMaxLength(250);
            builder.Property(c=>c.Description).IsRequired().HasMaxLength(5000);
            builder.Property(c => c.PermaLink).HasDefaultValue("http://www.msn.com");
            builder.Property(c=>c.IsActive).IsRequired().HasDefaultValue(false);
            builder.Property(c=>c.Priority).IsRequired();
            builder.Property(c=>c.BannerUrl).IsRequired().HasMaxLength(550).HasDefaultValue("https://via.placeholder.com/350");
            builder.Property(c=>c.IconUrl).IsRequired().HasMaxLength(550).HasDefaultValue("https://via.placeholder.com/850x350");
            builder.Property(c=>c.ThumbnailUrl).IsRequired().HasMaxLength(550).HasDefaultValue("https://via.placeholder.com/300x100");

            builder.HasMany(c=>c.Products).WithOne(c=>c.Category).HasForeignKey(c=>c.CategoryId);

            builder.HasOne(c=>c.ParentCategory).WithMany().HasForeignKey(c=>c.ParentCategoryId);

            List<Category> categories = new List<Category>();
           var cat001= Category.Create("Cat001","CatDesc001","http://wwww.microsoft.com",true,1, "https://via.placeholder.com/350x50", "https://via.placeholder.com/400x200", "https://via.placeholder.com/150x250", 1);
            cat001.Id = 1;
            categories.Add(cat001);
            var cat002 = Category.Create("Cat002", "CatDesc002", "http://wwww.mymap.com", true, 2, "https://via.placeholder.com/8500x600", "https://via.placeholder.com/600x400", "https://via.placeholder.com/950x650",parentCategpryId:1);
            cat002.Id = 2;       
            categories.Add(cat002);
            builder.HasData(categories);

        }
    }
}
