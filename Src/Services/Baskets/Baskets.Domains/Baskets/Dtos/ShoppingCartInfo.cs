using System;
namespace Baskets.Domains.Baskets.Dtos
{
    public class ShopingCartItemInfo
    {
        public int Quantity { get;  set; }
        public decimal Price { get;  set; }
        public string ProductId { get;  set; }
        public string ProductName { get;  set; }

    }

    public class ShopingCartInfo
    {
        public string UserName { get; set; }
        public List<ShopingCartItemInfo> ShopingCarts { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ShopingCartDto
    {
        public string UserName { get; set; }
        public List<ShopingCartItemInfo> ShopingCarts { get; set; }
    }

}

