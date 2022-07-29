using System;
using GraphQL.Types;
using MediatR;
using Products.Api.GQL.Types.Products.Responce;
using Products.Services.Products.Queries.GetAll;

namespace Products.Api.GQL.Queries
{
    public static class ProductQueries
    {
        public static void ProductQuery(this ObjectGraphType schema, IMediator mediator)
        {
            schema.Field<ListGraphType<ProductResType>>(
                name: "getProducts",
                description: "return list of products",
                resolve: context => mediator.Send(new GetAllProductQuery())
                );
        }
    }
}

