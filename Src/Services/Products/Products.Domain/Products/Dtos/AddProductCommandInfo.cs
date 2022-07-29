using System;
namespace Products.Domain.Products.Dtos
{
    public class AddProductCommandInfo
    {
        public long Id { get; set; }
        public string Titile { get;  set; }
        public string Description { get;  set; }
        public string PermaLink { get;  set; }
        public string CoverImageUrl { get;  set; }
        public decimal Price { get;  set; }
        public string Code { get;  set; }
        public long CategoryId { get;  set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long CreatedBy { get; set; }
    }


    public class ProductResInfo:AddProductCommandInfo
    {
        public string CategoryTitle { get; set; }
    }
}
