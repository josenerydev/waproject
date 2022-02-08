using waproject.Application.Common.Mappings;

namespace waproject.Application.Dtos.Orders
{
    public class OrderDto : IMapFrom<Domain.Entities.Order>
    {
        public long Id { get; set; }
        public string IdentificationNumber { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public string Address { get; set; } = default!;
    }

    public class OrdersListDto
    {
        public List<OrderDto> Orders { get; }
        public PagingInfo PagingInfo { get; }
        public OrdersListDto(List<OrderDto> orders, PagingInfo pagingInfo)
        {
            Orders = orders;
            PagingInfo = pagingInfo;
        }
    }

    public class PagingInfo
    {
        public int CurrentPage { get; }
        public int ItemsPerPage { get; }
        public int TotalItems { get; }
        public PagingInfo(int currentPage, int itemsPerPage, int totalItems)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
        }
    }
}
