using System;
using EventBus.Messages.Common;
using EventBus.Messages.Events;
using LoggingServices.Domains.Loggings.Dtos;
using LoggingServices.Domains.Loggings.Repositories;
using LoggingServices.Repositories.Loggings.Impliments;
using LoggingServices.Services.Loggings.Commands.Create;
using MassTransit;
using MongoDB.Driver;
using MediatR;
using LoggingServices.Services.EventBusConsumers;

namespace LoggingServices.Api.Extensions
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(typeof(AddLogDataCommand).Assembly);
            services.Configure<MongoDBSettings>(
                configuration.GetSection(nameof(MongoDBSettings))
            );

            services.AddSingleton<IMongoDatabase>(options => {
                var settings = configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
                var client = new MongoClient(settings.MongoConnectionString);
                return client.GetDatabase(settings.MongoDatabaseName);
            });

        }

        public static void AddScopedRegistry(this IServiceCollection services)
        {
            services.AddScoped<ILogRepository, LogRepository>();

        }

        public static void AddMessagingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(
     config =>
     {
         config.AddConsumer<AddLogDataConsumer>();
         config.UsingRabbitMq((ctx, cfg) =>
         {
             cfg.Host(configuration["EventBusSettings:HostAddress"]);
             cfg.ReceiveEndpoint(EventBusConstants.AddLogDataQueue, c =>
             {
                 c.ConfigureConsumer<AddLogDataConsumer>(ctx);
             });
         }
         );
     });
        }
    }
}

