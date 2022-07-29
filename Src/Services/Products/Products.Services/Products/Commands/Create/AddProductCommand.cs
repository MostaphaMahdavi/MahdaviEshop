using System;
using MediatR;
using Products.Domain.Products.Dtos;

namespace Products.Services.Products.Commands.Create
{
    public class AddProductCommand: AddProductCommandInfo,IRequest<ProductResInfo>
    {
       
    }
}
