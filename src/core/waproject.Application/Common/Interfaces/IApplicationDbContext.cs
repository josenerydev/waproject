using Microsoft.EntityFrameworkCore;

using waproject.Domain.Entities;

namespace waproject.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Carrier> Carriers { get; set; }
        DbSet<Domain.Entities.Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Domain.Entities.Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
