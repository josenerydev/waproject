using waproject.Application.Common.Mappings;
using waproject.Domain.Entities;

namespace waproject.Application.Dtos.Produtos
{
    public class ProdutoDto : IMapFrom<Produto>
    {
        public long Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
    }
}
