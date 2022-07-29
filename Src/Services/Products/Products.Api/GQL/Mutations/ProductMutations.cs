using System;
using GraphQL;
using GraphQL.Types;
using MediatR;
using Products.Api.GQL.Types.Products.Request;
using Products.Api.GQL.Types.Products.Responce;
using Products.Services.Products.Commands.Create;

namespace Products.Api.GQL.Mutations
{
    public static class ProductMutations
    {

        public static void ProductMutation(this ObjectGraphType schema, IMediator mediator)
        {
            schema.FieldAsync<ProductResType>(
               name: "addProduct",
               description: "Is use to add a new product to the database",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReqType>>
               {
                   Name = "productInput",
                   Description = "product input parameterrrr"
               }),
               resolve: async context =>
               {
                   var addProduct = context.GetArgument<AddProductCommand>("productInput");
                   return await mediator.Send(addProduct);
               }
               );
        }


    }
}

