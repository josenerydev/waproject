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
}
