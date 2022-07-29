using LoggingServices.Api.Extensions;
using LoggingServices.Domains.Loggings.Dtos;
using LoggingServices.Domains.Loggings.Repositories;
using LoggingServices.Repositories.Loggings.Impliments;
using MongoDB.Driver;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceRegistry(builder.Configuration);
builder.Services.AddScopedRegistry();
builder.Services.AddMessagingConfiguration(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

