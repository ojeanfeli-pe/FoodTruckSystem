namespace QueijoMoreno.Api.Models
{
    public class ItemPedido
    {
        public int Id { get; set; } // ID do item no banco

        public int PedidoId { get; set; } // Chave estrangeira para Pedido
        public Pedido Pedido { get; set; } // Navegação para o Pedido

        public int ProdutoId { get; set; } // Chave estrangeira para Produto
        public Produto Produto { get; set; } // Navegação para o Produto

        public int Quantidade { get; set; } // Quantidade do produto
        public string Observacao { get; set; } // Ex: “tirar cebola”, “bem passado”
        public decimal PrecoUnitario { get; set; } // Preço do produto no momento do pedido
    }
}
