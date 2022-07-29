using System;
using System.Text.Json;
using Baskets.Domains.Baskets.Entities;
using Baskets.Domains.Baskets.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Baskets.Repositories.Baskets.Impliments
{
    public class BasketRepository: IBasketRepository
    {
       private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache?? throw new ArgumentNullException("DistributedCache is null !!");
        }

        public async Task DeleteBasket(string userName)=>        
            await _redisCache.RemoveAsync(userName);
        

        public async Task<string> GetBasket(string userName)=>        
            await _redisCache.GetStringAsync(userName);
    
        public async Task UpdateBasket(ShoppingCart shoppingCard)=>
            await _redisCache.SetStringAsync(shoppingCard.UserName, JsonSerializer.Serialize(shoppingCard));
         
    }
}

