using System;
using Baskets.Domains.Baskets.Dtos;
using Baskets.Domains.Baskets.Entities;

namespace Baskets.Domains.Baskets.Services
{
    public interface IBasketService
    {
        Task<ShopingCartInfo> GetBasketAsync(string userName);
        Task<ShopingCartInfo> UpdateBasketAsync(ShopingCartDto shoppingCart);
        Task<dynamic> DeleteBasketAsync(string userName);
    }
}

