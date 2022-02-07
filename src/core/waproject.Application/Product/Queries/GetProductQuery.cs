using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using waproject.Application.Common.Interfaces;
using waproject.Application.Dtos.Products;

namespace waproject.Application.Product.Queries
{
    public class GetProductQuery : IRequest<IList<ProductDto>>
    {
    }

    public class GetProdutosQueryHandler : IRequestHandler<GetProductQuery, IList<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProdutosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return products;
        }
    }
}
