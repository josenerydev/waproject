namespace waproject.Domain.Entities
{
    public class Carrier
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string VehiclePlate { get; set; } = default!;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
