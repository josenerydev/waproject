namespace waproject.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string IdentificationNumber { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public string Address { get; set; } = default!;
        public List<OrderItem> OrderDetails { get; set; } = new List<OrderItem>();
    }
}
