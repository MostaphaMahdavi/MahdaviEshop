using System;
using MediatR;
using Products.Domain.Products.Dtos;

namespace Products.Services.Products.Queries.GetById
{
    public class GetByIdProductQuery:IRequest<ProductResInfo>
    {
        public long Id { get; set; }
    }

}
