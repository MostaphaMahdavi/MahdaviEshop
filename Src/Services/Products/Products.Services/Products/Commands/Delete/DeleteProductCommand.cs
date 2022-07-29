using System;
using MediatR;
using Products.Domain.Products.Dtos;

namespace Products.Services.Products.Commands.Delete
{
    public class DeleteProductCommand: DeleteProductCommandInfo,IRequest<bool>
    {
        
    }
}
