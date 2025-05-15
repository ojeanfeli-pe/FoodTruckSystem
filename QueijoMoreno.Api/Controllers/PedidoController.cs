using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueijoMoreno.Api.Data;
using QueijoMoreno.Api.Models;
using System.Text;

namespace QueijoMoreno.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            // Validação do cliente
            var cliente = _context.Clientes.Find(pedido.ClienteId);
            if (cliente == null)
                return BadRequest("Cliente não encontrado.");

            decimal totalPedido = 0;

            foreach (var item in pedido.Itens)
            {
                // Buscar o produto
                var produto = _context.Produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                if (produto == null)
                    return BadRequest($"Produto com ID {item.ProdutoId} não encontrado.");

                item.PrecoUnitario = produto.Preco;

                decimal subtotal = item.PrecoUnitario * item.Quantidade;

                // Calcular valor dos adicionais
                if (item.Adicionais != null && item.Adicionais.Count > 0)
                {
                    foreach (var adicionalItem in item.Adicionais)
                    {
                        var adicional = _context.Adicionais.FirstOrDefault(a => a.Id == adicionalItem.AdicionalId && a.Ativo);
                        if (adicional == null)
                            return BadRequest($"Adicional com ID {adicionalItem.AdicionalId} não encontrado ou está inativo.");

                        subtotal += adicional.Preco * item.Quantidade;

                        // Atribui a entidade Adicional ao item (opcional para resposta futura)
                        adicionalItem.Adicional = adicional;
                    }
                }

                totalPedido += subtotal;
            }

            // Adiciona taxa de entrega (se houver)
            totalPedido += pedido.TaxaEntrega;

            // Atualiza valores no pedido
            pedido.Total = totalPedido;
            pedido.DataHora = DateTime.Now;

            // Salva no banco
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        // Método GET para buscar um pedido pelo ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Busca o pedido incluindo os itens e os produtos de cada item
            var pedido = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .FirstOrDefault(p => p.Id == id);

            if (pedido == null)
                return NotFound("Pedido não encontrado.");

            return Ok(pedido);
        }

        // Método GET para listar todos os pedidos
        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .OrderByDescending(p => p.DataHora)
                .ToList();

            return Ok(pedidos);
        }

        // GET: Listar pedidos que ainda não foram pagos (pagar depois)
        [HttpGet("pendentes")]
        public IActionResult GetPedidosPendentes()
        {
            var pedidos = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .Where(p => p.PagarDepois && !p.Pago)
                .OrderByDescending(p => p.DataHora)
                .ToList();

            return Ok(pedidos);
        }

        // PUT: Confirmar pagamento de um pedido
        [HttpPut("{id}/confirmar-pagamento")]
        public IActionResult ConfirmarPagamento(int id)
        {
            var pedido = _context.Pedidos.Find(id);

            if (pedido == null)
                return NotFound("Pedido não encontrado.");

            if (!pedido.PagarDepois)
                return BadRequest("Este pedido não está marcado como 'pagar depois'.");

            pedido.Pago = true;
            _context.SaveChanges();

            return Ok("Pagamento confirmado com sucesso.");
        }

        [HttpGet("{id}/imprimir")]
        public IActionResult Imprimir(int id)
        {
            var pedido = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Adicionais)
                        .ThenInclude(a => a.Adicional)
                .FirstOrDefault(p => p.Id == id);

            if (pedido == null)
                return NotFound("Pedido não encontrado.");

            var texto = new StringBuilder();
            texto.AppendLine("====== QUEIJO MORENO LANCHES ======");
            texto.AppendLine($"Data: {pedido.DataHora:dd/MM/yyyy HH:mm}");
            texto.AppendLine($"Cliente: {pedido.Cliente?.Nome} {pedido.Cliente?.Sobrenome}");
            texto.AppendLine("------------------------------------");

            foreach (var item in pedido.Itens)
            {
                texto.AppendLine($"{item.Quantidade}x {item.Produto?.Nome} - R${item.PrecoUnitario:F2}");

                if (item.Adicionais != null && item.Adicionais.Any())
                {
                    foreach (var adicionalItem in item.Adicionais)
                    {
                        texto.AppendLine($"  + {adicionalItem.Adicional?.Nome} - R${adicionalItem.Adicional?.Preco:F2}");
                    }
                }

                if (!string.IsNullOrWhiteSpace(item.Observacao))
                {
                    texto.AppendLine($" Obs: {item.Observacao}");
                }

                texto.AppendLine(""); // espaço entre os itens
            }

            texto.AppendLine("Entrega:");

            if (!string.IsNullOrWhiteSpace(pedido.EnderecoEntrega))
                texto.AppendLine($"Endereço: {pedido.EnderecoEntrega}");

            texto.AppendLine($"Bairro: {pedido.Bairro}"); // deixado em branco como você pediu

            texto.AppendLine($"Forma de Pagamento: {pedido.FormaPagamento}");

            if (pedido.TaxaEntrega > 0)
                texto.AppendLine($"Taxa de Entrega: R${pedido.TaxaEntrega:F2}");

            texto.AppendLine("------------------------------------");
            texto.AppendLine($"TOTAL: R${pedido.Total:F2}");
            texto.AppendLine("====================================");

            return Ok(texto.ToString());
        }

    }
}
