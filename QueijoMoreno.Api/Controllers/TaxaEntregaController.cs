using Microsoft.AspNetCore.Mvc;
using QueijoMoreno.Api.Data;
using QueijoMoreno.Api.Models;

namespace QueijoMoreno.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxaEntregaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaxaEntregaController(AppDbContext context)
        {
            _context = context;
        }

        // POST: Cadastra uma nova taxa para um bairro
        [HttpPost]
        public IActionResult Post([FromBody] TaxaEntrega taxa)
        {
            _context.TaxasEntrega.Add(taxa);
            _context.SaveChanges();

            // Após cadastrar, retorna Created com link para GET por ID
            return CreatedAtAction(nameof(GetById), new { id = taxa.Id }, taxa);
        }

        // GET: Retorna todas as taxas ativas
        [HttpGet]
        public IActionResult Get()
        {
            var taxas = _context.TaxasEntrega
                .Where(t => t.Ativo)
                .ToList();

            return Ok(taxas);
        }

        // GET: Retorna uma taxa pelo nome do bairro
        [HttpGet("{bairro}")]
        public IActionResult GetByBairro(string bairro)
        {
            var taxa = _context.TaxasEntrega
                .FirstOrDefault(t => t.Bairro!.ToLower() == bairro.ToLower() && t.Ativo);

            if (taxa == null)
                return NotFound("Bairro não encontrado ou taxa desativada.");

            return Ok(taxa);
        }

        // GET: Retorna uma taxa pelo ID
        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var taxa = _context.TaxasEntrega.Find(id);

            if (taxa == null)
                return NotFound("Taxa não encontrada.");

            return Ok(taxa);
        }

        // PUT: Desativa a taxa (não exclui do banco)
        [HttpPut("{id}/desativar")]
        public IActionResult Desativar(int id)
        {
            var taxa = _context.TaxasEntrega.Find(id);

            if (taxa == null)
                return NotFound("Taxa não encontrada.");

            taxa.Ativo = false;
            _context.SaveChanges();

            return Ok("Taxa desativada com sucesso.");
        }
    }
}
