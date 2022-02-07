using MediatR;

using waproject.Application.Common.Interfaces;

namespace waproject.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<long>
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        public CreateProductCommand(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
