using System;
using System.Collections.Generic;
using MediatR;
using Products.Domain.Products.Dtos;

namespace Products.Services.Products.Queries.GetAll
{
    public class GetAllProductQuery:IRequest<IEnumerable<ProductResInfo>>
    {
       
    }
}
