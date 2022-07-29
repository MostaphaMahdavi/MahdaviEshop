using System;
using AutoMapper;
using Discounts.Domain.Coupons.Dtos;
using Discounts.Domain.Coupons.Entities;

namespace Discounts.Repositories.Coupons.Mapping
{
    public class CouponMappingProfile:Profile
    {
        public CouponMappingProfile()
        {
            CreateMap<Coupon, AddCouponInfo>().ReverseMap();
            CreateMap<Coupon,UpdateCouponInfo>().ReverseMap();
            CreateMap<Coupon,DeleteCouponInfo>().ReverseMap();
            CreateMap<Coupon, CouponInfo>().ForMember(desc=>desc.FullTitle,opt=>opt.MapFrom(s=>$"{s.ProductTitle} ({s.ProductId}) -> {s.Value}")).ReverseMap();
        }
    }
}
