using System;
using GraphQL.Types;
namespace Products.Api.GQL.Types.Products.Request
{
    public class ProductReqType:ObjectGraphType
    {
        public ProductReqType()
        {
            Name = nameof(ProductReqType);
            Field<IdGraphType>("Id");
            Field<StringGraphType>("Titile");
            Field<StringGraphType>("PermaLink");
            Field<DecimalGraphType>("Price");
            Field<StringGraphType>("CoverImageUrl");
            Field<StringGraphType>("Code");
            Field<StringGraphType>("Description");
            Field<StringGraphType>("CategoryTitle");
            Field<LongGraphType>("CategoryId");
        }
    }
}

