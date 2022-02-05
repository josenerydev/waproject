using Microsoft.EntityFrameworkCore;

using waproject.Domain.Entities;

namespace waproject.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipe> Equipes { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<PedidoItem> PedidoItems { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;
    }
}
