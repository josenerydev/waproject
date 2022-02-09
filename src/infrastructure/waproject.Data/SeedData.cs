using Bogus;

using Microsoft.Extensions.DependencyInjection;

using waproject.Data.Contexts;
using waproject.Domain.Entities;

namespace waproject.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            int carrierNumber = 10;

            List<Carrier> carries = new();
            for (int i = 0; i < carrierNumber; i++)
            {
                var orderFaker = new OrderFaker();
                var orders = orderFaker.Generate(10);

                foreach (var order in orders)
                {
                    order.OrderDetails.AddRange(GenerateOrderItemFake(order));
                }

                var carrierFaker = new CarrierFaker(orders);
                carries.Add(carrierFaker.Generate());
            }

            context.Carriers.AddRange(carries);

            await context.SaveChangesAsync();
        }

        public static List<OrderItem> GenerateOrderItemFake(Order order)
        {
            var orderItemFaker = new OrderItemFaker(order);
            return orderItemFaker.Generate(5);
        }
    }

    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(o => o.Name, f => f.Commerce.Product());
            RuleFor(o => o.Description, f => f.Lorem.Sentence(15));
            RuleFor(o => o.Price, f => decimal.Parse(f.Commerce.Price()));
        }
    }

    public class OrderFaker : Faker<Order>
    {
        public OrderFaker()
        {
            RuleFor(o => o.IdentificationNumber, f => f.Random.Guid().ToString());
            RuleFor(o => o.CreatedAt, f => f.Date.Past());
            RuleFor(o => o.DeliveredAt, f => f.Date.Future());
            RuleFor(o => o.Address, f => f.Address.FullAddress());
        }
    }

    public class OrderItemFaker : Faker<OrderItem>
    {
        public OrderItemFaker(Order order)
        {
            var productFaker = new ProductFaker();
            RuleFor(o => o.Order, f => order);
            RuleFor(o => o.Product, f => productFaker.Generate());
        }
    }

    public class CarrierFaker : Faker<Carrier>
    {
        public CarrierFaker(List<Order> orders)
        {
            RuleFor(o => o.Name, f => f.Company.CompanyName());
            RuleFor(o => o.Description, f => f.Lorem.Sentence(10));
            RuleFor(o => o.VehiclePlate, f => f.Vehicle.Vin());
            RuleFor(o => o.Orders, f => orders);
        }
    }
}
