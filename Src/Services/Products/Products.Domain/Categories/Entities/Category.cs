using System;
using MahdaviEshop.Framework.Entities;
using Products.Domain.Products.Entities;

namespace Products.Domain.Categories.Entities
{
    public class Category:BaseEntity
    {
        public string Title { get;private set; }
        public string  Description { get;private set; }
        public long? ParentCategoryId { get;private set; }
        public string PermaLink { get;private set; }
        public bool IsActive { get;private set; }
        public int Priority { get;private set; }
        public string BannerUrl { get;private set; }
        public string IconUrl { get;private set; }
        public string ThumbnailUrl { get;private set; }


        public List<Product> Products { get; set; }
        public Category ParentCategory { get; set; }

        private Category()
        {
        }

        private Category(string title,string description,string permaLink,bool isActive,int priority,string bannerUrl,string iconUrl,string thumbnailUrl,int? parentCategpryId=null)
        {
            Title = title;
            Description = description;
            ParentCategoryId = parentCategpryId;
            PermaLink = permaLink;
            IsActive = isActive;
            BannerUrl = bannerUrl;
            IconUrl = iconUrl;
            ThumbnailUrl = thumbnailUrl;
            CreatedDate = DateTime.Now;
            UpdatedDate = null;
            DeletedDate = null;
          
        }

        public static Category Create(string title, string description, string permaLink, bool isActive, int priority, string bannerUrl, string iconUrl, string thumbnailUrl, int? parentCategpryId = null)
        {
            return new Category(title,description,permaLink,isActive,priority,bannerUrl,iconUrl,thumbnailUrl,parentCategpryId);
        }
    }
}
