using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Products.Domain.Products.Entities;
using Products.Domain.UnitOfWorks;

namespace Products.Services.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        ICommandUnitOfWork _command;
        public UpdateProductCommandHandler(ICommandUnitOfWork command)
        {
            _command = command;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Titile, request.Description, isActive: false, request.PermaLink, request.CoverImageUrl, request.Price, request.Code, request.CategoryId);
            product.Id = request.Id;

            _command.ProductCommandRepository.Update(product);
            await _command.SaveAsync();
            return product;
        }
    }
}
