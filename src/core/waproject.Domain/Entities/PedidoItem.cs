namespace waproject.Domain.Entities
{
    public class PedidoItem
    {
        public long Id { get; set; }
        public Pedido Pedido { get; set; } = new Pedido();
        public Produto Produto { get; set; } = new Produto();
    }
}
