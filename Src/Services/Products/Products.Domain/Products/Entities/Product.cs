using System;
using MahdaviEshop.Framework.Entities;
using Products.Domain.Categories.Entities;

namespace Products.Domain.Products.Entities
{
    public class Product:BaseEntity
    {
        public string Titile { get;private set; }
        public string Description { get;private set; }
        public bool IsActive { get;private set; }
        public string PermaLink { get;private set; }
        public string CoverImageUrl { get;private set; }
        public decimal Price { get;private set; }
        public string Code { get;private set; }
        public long CategoryId { get;private set; }
        public Category Category { get; set; }


        private Product()
        {

        }
        private Product(string title,string description,bool isActive,string permaLink,
            string coverImageUrl,decimal price,string code,long categoryId)
        {
            Titile = title;
            Description = description;
            IsActive = isActive;
            PermaLink = permaLink;
            CoverImageUrl = coverImageUrl;
            Price = price;
            Code = code;
            CategoryId = categoryId;
            CreatedDate = DateTime.Now;
            UpdatedDate = null;
            DeletedDate = null;
                
        }

        public static Product Create(string title, string description, bool isActive, string permaLink,
            string coverImageUrl, decimal price, string code, long categoryId)
        {
            return new Product(title,description,isActive,permaLink,coverImageUrl,price,
                coverImageUrl,categoryId);

        }

    }

}
