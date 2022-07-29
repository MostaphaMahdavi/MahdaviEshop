using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Products.Domain.Products.Dtos;
using Products.Domain.UnitOfWorks;

namespace Products.Services.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductResInfo>
    {
        IQUeryUnitOfWork _query;
        IMapper _mapper;

        public GetByIdProductQueryHandler(IQUeryUnitOfWork query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<ProductResInfo> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductResInfo>(await _query.ProductQueryRepository.GetByIdAsNoTrackingAsync(request.Id));
        }
    }

}
