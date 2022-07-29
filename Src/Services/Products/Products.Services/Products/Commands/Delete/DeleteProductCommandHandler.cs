using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Products.Domain.UnitOfWorks;

namespace Products.Services.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        ICommandUnitOfWork _command;
        IQUeryUnitOfWork _query;
        public DeleteProductCommandHandler(ICommandUnitOfWork command, IQUeryUnitOfWork query)
        {
            _command = command;
            _query = query;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _query.ProductQueryRepository.GetByIdAsync(request.Id);
            if (product is null)
            {
                return false;
            }
            _command.ProductCommandRepository.Delete(product);
            await _command.SaveAsync();
            return true;
        }
    }
}
