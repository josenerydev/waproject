using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using waproject.Application.Common.Interfaces;
using waproject.Application.Dtos.Orders;

namespace waproject.Application.Order.Queries
{
    public class GetOrdersQuery : IRequest<OrdersListDto>
    {
        public int Page { get; }
        public int PageSize { get; }
        public GetOrdersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, OrdersListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrdersListDto> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .OrderBy(tp => tp.CreatedAt)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var totalItems = await _context.Orders
                .AsNoTracking().CountAsync(cancellationToken);

            var ordersListDto = new OrdersListDto(orders, new PagingInfo(request.Page, request.PageSize, totalItems));

            return ordersListDto;
        }
    }
}
