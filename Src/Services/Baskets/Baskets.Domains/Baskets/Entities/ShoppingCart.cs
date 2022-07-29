using System;
namespace Baskets.Domains.Baskets.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShopingCartItem> ShopingCarts { get; set; } = new List<ShopingCartItem>();


        public decimal TotalPrice { get
            {
                decimal total = 0;
                foreach (var item in ShopingCarts)
                {
                    total += item.Price*item.Quantity;
                }
                return total;
            } }
    }
}

