
using Microsoft.EntityFrameworkCore;

using waproject.Domain.Entities;

namespace waproject.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Equipe> Equipes { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<PedidoItem> PedidoItems { get; set; }
        DbSet<Domain.Entities.Produto> Produtos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
