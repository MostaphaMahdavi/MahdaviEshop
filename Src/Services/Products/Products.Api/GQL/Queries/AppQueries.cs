using System;
using GraphQL.Types;
using MediatR;

namespace Products.Api.GQL.Queries
{
    public class AppQueries:ObjectGraphType
    {
        public AppQueries(IMediator _mediatr)
        {
            this.ProductQuery(_mediatr);
        }
    }
}

