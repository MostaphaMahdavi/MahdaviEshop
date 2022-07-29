using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Products.Domain.Products.Dtos;
using Products.Domain.UnitOfWorks;

namespace Products.Services.Products.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductResInfo>>
    {
        IQUeryUnitOfWork _query;
        IMapper _mapper;
        public GetAllProductQueryHandler(IQUeryUnitOfWork query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductResInfo>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ProductResInfo>>(await _query.ProductQueryRepository.GetAllAsNoTrackingAsync());
        }
    }
}
