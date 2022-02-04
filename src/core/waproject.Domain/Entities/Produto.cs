namespace waproject.Domain.Entities
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
    }
}
