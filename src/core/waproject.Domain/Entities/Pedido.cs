namespace waproject.Domain.Entities
{
    public class Pedido
    {
        public long Id { get; set; }
        public string NumeroIdentificacao { get; set; } = default!;
        public DateTime DataCriacao { get; set; }
        public DateTime DataEntregaRealizada { get; set; }
        public string Endereço { get; set; } = default!;
    }
}
