using GraphQL.Server;
using MahdaviEshop.Framework.Dtos.Settings;
using Products.Api.Extentions;
using Products.Api.GQL.Mutations;
using Products.Api.GQL.Queries;
using Products.Api.GQL.Schemas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddContext(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddServiceRegistery();
builder.Services.AddMessagingConfiguration(builder.Configuration);
builder.Services.AddGraphQL().AddSystemTextJson();


var setting = builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection(nameof(SiteSettings)));

//builder.Services.AddSingleton<IMongoDatabase>(options => {
//    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
//    var client = new MongoClient(settings.ConnectionString);
//    return client.GetDatabase(settings.DatabaseName);
//});

builder.Services.AddJwtAuthentitaction(setting);
builder.Services.AddScoped<AppMutations>();
builder.Services.AddScoped<AppQueries>();
builder.Services.AddScoped<AppSchema>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

