namespace waproject.Domain.Entities
{
    public class OrderItem
    {
        public long Id { get; set; }
        public Order Order { get; set; } = new Order();
        public Product Product { get; set; } = new Product();
    }
}
