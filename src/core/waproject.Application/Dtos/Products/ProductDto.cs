using waproject.Application.Common.Mappings;

namespace waproject.Application.Dtos.Products
{
    public class ProductDto : IMapFrom<Domain.Entities.Product>
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
