namespace waproject.Domain.Entities
{
    public class Equipe
    {
        public long Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public string PlacaVeiculo { get; set; } = default!;
    }
}
