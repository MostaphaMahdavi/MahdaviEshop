using EventBus.Messages.Events;
using MahdaviEshop.Framework.ServiceProvider;
using MassTransit;
using Products.Domain.Products.Repositories;
using Products.Domain.UnitOfWorks;
using Products.Repository.Products.Impliments;
using Products.Repository.UnitOfWorks;
using Polly;
using MahdaviEshop.Framework.ServiceProvider.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MahdaviEshop.Framework.Dtos.Settings;
using Microsoft.IdentityModel.Tokens;

namespace Products.Api.Extentions
{
    public static class ServiceRegisteryExtention
    {
        public static void AddServiceRegistery(this IServiceCollection services)
        {
            services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();
            services.AddScoped<IQUeryUnitOfWork, QueryUnitOfWork>();
            services.AddScoped<IServiceProvicer, ServiceProvicer>();
            services.AddScoped<IJwtService, JwtService>();


            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();


            services.AddHttpClient<ServiceProvicer>()
               .AddTransientHttpErrorPolicy(p =>
               p.CircuitBreakerAsync(2, TimeSpan.FromSeconds(10)));


        }
        public static void AddJwtAuthentitaction(this IServiceCollection services,SiteSettings siteSettings)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme =JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                var secretKey = System.Text.Encoding.UTF8.GetBytes(siteSettings.SecurityKey);

                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens=true,
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    RequireExpirationTime=true,
                    ValidateLifetime=true,
                    ValidateAudience=true,
                    ValidAudience= siteSettings.Audience,
                    ValidateIssuer=true,
                    ValidIssuer= siteSettings.Issuer,
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
            });

            services.AddAuthorization();

         }
        public static void AddMessagingConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            //services.AddMassTransit(x =>
            //{

            //    x.UsingRabbitMq((ctx,cfg) =>
            //    {
            //        cfg.Host(configuration["EventBusSettings:HostAddress"]);
            //    });
            //    x.AddConsumers(typeof(BaseEvent).Assembly);
            //});




            services.AddMassTransit(x =>
            {

                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                });

                x.AddConsumers(typeof(BaseEvent).Assembly);
            });
            // OPTIONAL, but can be used to configure the bus options
            services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    // if specified, waits until the bus is started before
                    // returning from IHostedService.StartAsync
                    // default is false
                    options.WaitUntilStarted = true;

                    // if specified, limits the wait time when starting the bus
                    options.StartTimeout = TimeSpan.FromSeconds(10);

                    // if specified, limits the wait time when stopping the bus
                    options.StopTimeout = TimeSpan.FromSeconds(30);
                });
        }
    }
}
