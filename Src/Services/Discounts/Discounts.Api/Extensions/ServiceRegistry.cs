using System;
using Discounts.DataAccessLayer.Context;
using Discounts.Domain.Coupons.Entities;
using Discounts.Domain.Coupons.Repositories;
using Discounts.Domain.UnitOfWorks;
using Discounts.Repositories.Coupons.Impliments;
using Discounts.Repositories.Coupons.Mapping;
using Discounts.Repositories.UnitOfWorks;
using Discounts.Services.Behaviors;
using Discounts.Services.Coupons.Commands.Create;
using Discounts.Services.EventBusConsumers;
using EventBus.Messages.Common;
using FluentValidation;
using GraphQL.Server;
using MahdaviEshop.Framework.ServiceProvider;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discounts.Api.Extensions
{
    public static class ServiceRegistry
    {
       public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(CouponMappingProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(AddCouponCommandValidator).Assembly);
            services.AddMediatR(typeof(AddCouponCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddGraphQL().AddSystemTextJson();
        }

        public static void AddDbContextRegistry(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CouponContext>(option=>option.UseNpgsql(configuration["ConnectionStrings:DiscountDb"]));

        }


        public static void AddScopedRegistry(this IServiceCollection services)
        {
            services.AddScoped<ICouponCommandUnitOfWork, CouponCommandUnitOfWork>();
            services.AddScoped<ICouponQueryUnitOfWork, CouponQueryUnitOfWork>();
            services.AddScoped<IServiceProvicer, ServiceProvicer>();

            services.AddScoped<ICouponCommandRepository, CouponCommandRepository>();
            services.AddScoped<ICouponQueryRepository, CouponQueryRepository>();

        }

        public static void AddMessagingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {            services.AddMassTransit(
              config =>
              {
                  config.AddConsumer<AddProductConsumer>();
                  config.UsingRabbitMq((ctx, cfg) =>
                  {
                      cfg.Host(configuration["EventBusSettings:HostAddress"]);
                      cfg.ReceiveEndpoint(EventBusConstants.AddProductQueue, c =>
                      {
                          c.ConfigureConsumer<AddProductConsumer>(ctx);
                      });
                  }
                  );
              });
        }
    }
}
