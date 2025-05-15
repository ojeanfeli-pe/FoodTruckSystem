namespace QueijoMoreno.Api.Models
{
    public class ItemPedidoAdicional
    {
        public int Id { get; set; }
        public int ItemPedidoId { get; set; } // FK para o item
        public int ProdutoId { get; set; }
        
        public ItemPedido ItemPedido { get; set; } = null!;
        public Adicional Adicional { get; set; } = null!;

        public int AdicionalId { get; set; }          // FK para o adicional
    }
}