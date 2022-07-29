using System;
using MahdaviEshop.Framework.Entities;

namespace Baskets.Domains.Baskets.Entities
{
    public class ShopingCartItem:BaseEntity
    {
        public int Quantity { get;private set; }
        public decimal Price { get;private set; }
        public string ProductId { get;private set; }
        public string ProductName { get;private set; }

        private ShopingCartItem()
        {

        }

        private ShopingCartItem(int quantity,decimal price,string productId,string productName)
        {
            Quantity = quantity;
            Price = price;
            ProductId = productId;
            ProductName = productName;
        }

        public static ShopingCartItem Create(int quantity, decimal price, string productId, string productName)
        {
            return new ShopingCartItem(quantity, price, productId, productName);
        }
    }
}

