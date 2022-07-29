using System;
using System.Text.Json;
using Baskets.Domains.Baskets.Dtos;
using Baskets.Domains.Baskets.Entities;
using Baskets.Domains.Baskets.Repositories;
using Baskets.Domains.Baskets.Services;

namespace Baskets.Services.Baskets
{
    public class BasketService: IBasketService
    {
        IBasketRepository _basket;        

        public BasketService(IBasketRepository basket)
        {
            _basket = basket;
        }

        public async Task<dynamic> DeleteBasketAsync(string userName)
        {
            if (userName is null)
            {
                return new { RepsonseCode = 104, ResponceMessage = "یافت نشد." };
            }
            if (await _basket.GetBasket(userName) is null)
            {
                return new { RepsonseCode = 104, ResponceMessage = "یافت نشد." };
            }
            await _basket.DeleteBasket(userName);
            return new { RepsonseCode = 200, ResponceMessage = "با موفقیت حذف شد" };
        }

        public async Task<ShopingCartInfo> GetBasketAsync(string userName)
        {
           var basketData= await _basket.GetBasket(userName);
            if (basketData is null)
            {
                throw new Exception($"{userName} یافت نشد");
            }
            return JsonSerializer.Deserialize<ShopingCartInfo>(basketData);        

        }

        public async Task<ShopingCartInfo> UpdateBasketAsync(ShopingCartDto shoppingCartInfo)
        {

            var shoppinggg = shoppingCartInfo.ShopingCarts
                .Select(s=>ShopingCartItem.Create(s.Quantity,s.Price,s.ProductId,s.ProductName))
                .ToList();

            ShoppingCart shoppingCart = new ShoppingCart
            {
                UserName = shoppingCartInfo.UserName,
                ShopingCarts = shoppinggg

            };      

            await _basket.UpdateBasket(shoppingCart);
            return await GetBasketAsync(shoppingCart.UserName);
        }
    }
}

