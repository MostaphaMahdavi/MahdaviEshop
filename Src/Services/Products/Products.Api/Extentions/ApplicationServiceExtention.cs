using MediatR;
using Products.Repository.Products.Mapping;
using Products.Services.Behaviors;
using Products.Services.Products.Commands.Create;
using FluentValidation;

namespace Products.Api.Extentions
{
    public static class ApplicationServiceExtention
    {
        public static void AddApplicationService(this IServiceCollection services)
        {

            services.AddValidatorsFromAssembly(typeof(AddProductCommandValidator).Assembly);

            services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
            services.AddMediatR(typeof(AddProductCommand).Assembly);


            services.AddScoped(typeof(IPipelineBehavior<,>),typeof(UnhandledExceptionBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviour<,>));



        }
    }
}
