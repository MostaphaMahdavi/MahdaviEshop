using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.DataAccessLayer.Context;

namespace Products.Api.Extentions
{
    public static class DatabaseExtention
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MahdaviContext>(option=>
            {
                option.UseNpgsql(configuration["ConnectionStrings:ProductDb"]);
            });
        }
       
    }
}
