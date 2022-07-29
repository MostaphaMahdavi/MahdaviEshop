using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Products.Domain.Products.Dtos;
using Products.Domain.Products.Entities;
using Products.Domain.UnitOfWorks;

namespace Products.Services.Products.Commands.Create
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductResInfo>
    {
        ICommandUnitOfWork _command;
        IMapper _mapper;
        IPublishEndpoint _publishEndpoint;
        public AddProductCommandHandler(ICommandUnitOfWork command, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _command = command;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ProductResInfo> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var pro = await _command.ProductCommandRepository.AddAsync(_mapper.Map<Product>(request));
            await _command.SaveAsync();
            var productEvent = new AddedProductEvent
            {
                ProductId=pro.Id,
                ProductTitle=pro.Titile
                
            };
            await _publishEndpoint.Publish(productEvent);

            var logDataEvent = new AddLogDataEvent
            {
                ControllerName="MyController",
                ActionName= "AddProductCommandHandler",
                LogLevel="Info",
                Message=JsonSerializer.Serialize(request)
            };
            await _publishEndpoint.Publish(logDataEvent);
            return _mapper.Map<ProductResInfo>(pro);
        }
    }
}
