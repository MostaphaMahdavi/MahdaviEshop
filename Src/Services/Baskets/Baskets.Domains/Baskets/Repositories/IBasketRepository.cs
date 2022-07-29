using System;
using Baskets.Domains.Baskets.Entities;

namespace Baskets.Domains.Baskets.Repositories
{
    public interface IBasketRepository
    {
        Task<string> GetBasket(string userName);
        Task UpdateBasket(ShoppingCart shoppingCard);
        Task DeleteBasket(string userName);
    }
}

