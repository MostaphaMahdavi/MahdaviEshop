using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MahdaviEshop.Framework.Controllers;
using MahdaviEshop.Framework.Entities;
using MahdaviEshop.Framework.Enums;
using MahdaviEshop.Framework.ServiceProvider;
using MahdaviEshop.Framework.ServiceProvider.Jwt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.Products.Dtos;
using Products.Domain.Products.Entities;
using Products.Domain.UnitOfWorks;
using Products.Services.Products.Commands.Create;
using Products.Services.Products.Commands.Delete;
using Products.Services.Products.Commands.Update;
using Products.Services.Products.Queries.GetAll;
using Products.Services.Products.Queries.GetById;

namespace Products.Api.Controllers
{
    public class ProductController : BaseController
    {

        private readonly IMediator _mediator;
        IServiceProvicer _service;
        IJwtService _jwtService;
        public ProductController(IMediator mediator, IServiceProvicer service, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _service = service;
            _mediator = mediator;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<dynamic> GetToken(string userName,string password)
        {
            var jwt = _jwtService.Generate(new User
            {
                UserId = 1,
                UserName = userName,
                Password = password,
                Address = "AddressData",
                Mobile = "09127996346"
            });
            return new {Code=200,Messgae="عملیات موفق",Token=jwt };
        }

        [HttpGet]       
        public async Task<IEnumerable<ProductResInfo>> Get()
        {         
            // var fds =await _service.Rest(url: @"https://jsonplaceholder.typicode.com/posts", "", parameters: null, headers: null, parameterType: RestSharp.ParameterType.GetOrPost, method: RestSharp.Method.GET); ;
             
           // var res= await _service.PollyRequest(baseAddress: @"https://jsonplaceholder.typicode.com/posts",parameters:null,headers:null,callServiceType:CallServiceType.Get);
            return await _mediator.Send(new GetAllProductQuery());
        }

        [HttpGet("[Action]/{id}")]
        public async Task<ProductResInfo> GetProductById(long id)
        {
            return await _mediator.Send(new GetByIdProductQuery {Id=id });
        }

        [HttpPost]
        public async Task<ProductResInfo> AddProduct(AddProductCommand product)
        {
         return await _mediator.Send(product);
        }

        [HttpPut]
        public async Task<Product> UpdateaProduct(UpdateProductCommand product)
        {
           return await _mediator.Send(product);
        }

        [HttpDelete]
        public async Task DeleteProduct(DeleteProductCommand product)
        {
            await _mediator.Send(product);
        }

    }
}
