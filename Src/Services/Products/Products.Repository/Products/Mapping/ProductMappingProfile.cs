using System;
using AutoMapper;
using Products.Domain.Products.Dtos;
using Products.Domain.Products.Entities;

namespace Products.Repository.Products.Mapping
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<AddProductCommandInfo, Product>().ReverseMap();
            CreateMap<Product,ProductResInfo>().ForMember(c=>c.CategoryTitle,des=>des.MapFrom(s=>$"catTitle: {s.Category.Title} - catId: {s.Category.Id} - catPrice: {s.Category.Priority}")).ReverseMap();
            CreateMap<UpdateProductCommandInfo, Product>().ReverseMap();
        }
    }
}
