using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueijoMoreno.Api.Data;
using QueijoMoreno.Api.Models;

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

        // Método POST para registrar um novo pedido
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            // Verifica se o cliente existe antes de salvar o pedido
            var cliente = _context.Clientes.Find(pedido.ClienteId);
            if (cliente == null)
                return BadRequest("Cliente não encontrado.");

            // Calcula o total dos itens
            decimal totalDosItens = 0;

            foreach (var item in pedido.Itens)
            {
                // Busca o produto no banco de dados
                var produto = _context.Produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                if (produto == null)
                    return BadRequest($"Produto com ID {item.ProdutoId} não encontrado.");

                // Define o preço unitário e calcula o subtotal
                item.PrecoUnitario = produto.Preco;
                totalDosItens += item.PrecoUnitario * item.Quantidade;
            }

            // Soma com a taxa de entrega (se houver)
            pedido.Total = totalDosItens + pedido.TaxaEntrega;

            // Define o horário atual
            pedido.DataHora = DateTime.Now;

            // Salva o pedido e os itens
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

    }
}
