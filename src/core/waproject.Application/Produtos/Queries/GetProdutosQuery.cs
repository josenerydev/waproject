using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using waproject.Application.Common.Interfaces;
using waproject.Application.Dtos.Produtos;

namespace waproject.Application.Produtos.Queries
{
    public class GetProdutosQuery : IRequest<IList<ProdutoDto>>
    {
    }

    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, IList<ProdutoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProdutosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProdutoDto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _context.Produtos
                .ProjectTo<ProdutoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return produtos;
        }
    }
}
