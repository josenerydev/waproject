using Microsoft.EntityFrameworkCore;

using waproject.Application.Common.Interfaces;
using waproject.Domain.Entities;

namespace waproject.Data.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipe> Equipes { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<PedidoItem> PedidoItems { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
