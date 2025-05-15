using Microsoft.AspNetCore.Mvc; // Para criar a API e os controladores
using Microsoft.EntityFrameworkCore;
using QueijoMoreno.Api.Data;    // Acesso ao banco de dados (AppDbContext)
using QueijoMoreno.Api.Models;  // Acesso ao modelo Cliente


namespace QueijoMoreno.Api.Controllers
{
    // Indica que esta classe é um Controller de API
    [ApiController]

    // Define a rota base da URL para este controller: /api/caixa
    [Route("api/[controller]")]
    public class CaixaController : ControllerBase
    {
        // Campo privado para acessar o banco de dados
        private readonly AppDbContext _context;

        // Construtor: recebe o contexto do banco via injeção de dependência
        public CaixaController(AppDbContext context)
        {
            _context = context;
        }

          // POST: Abrir caixa do dia
        [HttpPost("abrir")]
        public IActionResult Abrir([FromBody] decimal valorInicial)
        {
            // Evita abrir mais de um caixa no mesmo dia
            if (_context.Caixas.Any(c => c.Data == DateTime.Today))
                return BadRequest("Caixa do dia já foi aberto.");

            var caixa = new Caixa
            {
                ValorInicial = valorInicial
            };

            _context.Caixas.Add(caixa);
            _context.SaveChanges();

            return Ok("Caixa aberto com sucesso.");
        }

        // PUT: Fechar caixa do dia
        [HttpPut("fechar")]
        public IActionResult Fechar()
        {
            var caixa = _context.Caixas
                .Include(c => c.Pedidos)
                .FirstOrDefault(c => c.Data == DateTime.Today);

            if (caixa == null)
                return NotFound("Caixa de hoje não encontrado.");

            if (caixa.Fechado)
                return BadRequest("Caixa já foi fechado.");

            // Busca todos os pedidos pagos de hoje
            var pedidosDoDia = _context.Pedidos
                .Where(p => p.DataHora.Date == DateTime.Today && p.Pago)
                .ToList();

            // Atribui os pedidos ao caixa
            caixa.Pedidos = pedidosDoDia;

            // Calcula valor total
            var totalVendas = pedidosDoDia.Sum(p => p.Total);
            caixa.ValorFinal = caixa.ValorInicial + totalVendas;
            caixa.Fechado = true;

            _context.SaveChanges();

            return Ok($"Caixa fechado. Total do dia: R${caixa.ValorFinal}");
        }

        // GET: Listar caixas anteriores
        [HttpGet]
        public IActionResult Get()
        {
            var caixas = _context.Caixas
                .OrderByDescending(c => c.Data)
                .ToList();

            return Ok(caixas);
        }
    }
}