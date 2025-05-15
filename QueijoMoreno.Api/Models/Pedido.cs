using System;
using System.Collections.Generic;

namespace QueijoMoreno.Api.Models
{
    public class Pedido
    {
        public int Id { get; set; } // Identificador único do pedido
        public string? Bairro { get; set; }

        public int? CaixaId { get; set; }              // Caixa ao qual esse pedido pertence
        public Caixa? Caixa { get; set; }

        public int ClienteId { get; set; } // Chave estrangeira para Cliente
        public Cliente? Cliente { get; set; } // Navegação para o objeto Cliente

        public List<ItemPedido> Itens { get; set; } = new(); // Lista de produtos do pedido

        public string? FormaEntrega { get; set; } // Ex: "Entrega", "Retirada", "Consumir no local"
        public string? EnderecoEntrega { get; set; } // Endereço para entrega (se houver)
        public string? FormaPagamento { get; set; } // Ex: Pix, Dinheiro, Cartão
        public string? Observacoes { get; set; } // Qualquer observação do cliente
        public bool PagarDepois { get; set; } = false;  // Define se o pedido será pago depois
        public bool Pago { get; set; } = false;         // Indica se o pagamento já foi feito
        public decimal TaxaEntrega { get; set; } // Valor da taxa de entrega
        public decimal Total { get; set; } // Valor total do pedido (soma dos itens + taxa)

        public DateTime DataHora { get; set; } = DateTime.Now; // Data e hora do pedido
    }
}
