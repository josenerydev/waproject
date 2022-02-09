using waproject.Application.Dtos.Common;

namespace waproject.Application.Dtos.Orders
{
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
}
