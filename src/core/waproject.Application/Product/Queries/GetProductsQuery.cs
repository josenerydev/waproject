using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using waproject.Application.Common.Interfaces;
using waproject.Application.Dtos.Products;

namespace waproject.Application.Product.Queries
{
    public class GetProductsQuery : IRequest<IList<ProductDto>>
    {
    }

    public class GetProdutosQueryHandler : IRequestHandler<GetProductsQuery, IList<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProdutosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return products;
        }
    }
}
