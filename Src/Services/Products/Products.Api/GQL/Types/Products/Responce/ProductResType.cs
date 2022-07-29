using System;
using GraphQL.Types;
using Products.Domain.Products.Dtos;

namespace Products.Api.GQL.Types.Products.Responce
{
    public class ProductResType:ObjectGraphType<ProductResInfo>
    {
        public ProductResType()
        {
            Field(x=>x.Id,type:typeof(IdGraphType));
            Field(x=>x.Titile,type:typeof(StringGraphType));
            Field(x=>x.PermaLink,type:typeof(StringGraphType));
            Field(x => x.Price, type: typeof(DecimalGraphType));
            Field(x => x.CoverImageUrl, type: typeof(StringGraphType));
            Field(x => x.Code, type: typeof(StringGraphType));
            Field(x => x.Description, type: typeof(StringGraphType));
            Field(x => x.CategoryTitle, type: typeof(StringGraphType));
            Field(x => x.CategoryId, type: typeof(LongGraphType));
        }
    }
}

