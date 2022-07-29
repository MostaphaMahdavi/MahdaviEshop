using System;
using AutoMapper;
using MediatR;
using Products.Domain.Products.Dtos;
using Products.Domain.Products.Entities;
using Products.Repository.UnitOfWorks;

namespace Products.Services.Products.Commands.Update
{
    public class UpdateProductCommand: UpdateProductCommandInfo,IRequest<Product>
    {
       
    }
}
