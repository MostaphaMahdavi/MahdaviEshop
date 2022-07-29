using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baskets.Domains.Baskets.Dtos;
using Baskets.Domains.Baskets.Entities;
using Baskets.Domains.Baskets.Services;
using MahdaviEshop.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Baskets.Api.Controllers
{

    public class BasketController : BaseController
    {
       private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

       
        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            return Ok(await _basketService.GetBasketAsync(userName));
        }
   
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShopingCartDto shoppingCart)
        {
           return Ok(await _basketService.UpdateBasketAsync(shoppingCart));
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            return Ok(await _basketService.DeleteBasketAsync(userName));
        }
    }
}

