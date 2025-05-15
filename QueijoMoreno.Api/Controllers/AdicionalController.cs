using Microsoft.AspNetCore.Mvc;
using QueijoMoreno.Api.Data;
using QueijoMoreno.Api.Models;

namespace QueijoMoreno.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdicionalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdicionalController(AppDbContext context)
        {
            _context = context;
        }

        
        // POST: cadastrar novo adicional
        [HttpPost]
        public IActionResult Post([FromBody] Adicional adicional)
        {
            _context.Adicionais.Add(adicional);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = adicional.Id }, adicional);
        }

        // GET: listar todos os adicionais ativos
        [HttpGet]
        public IActionResult Get()
        {
            var adicionais = _context.Adicionais
                .Where(a => a.Ativo)
                .ToList();

            return Ok(adicionais);
        }

        // GET: buscar adicional por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var adicional = _context.Adicionais.Find(id);

            if (adicional == null)
                return NotFound("Adicional não encontrado.");

            return Ok(adicional);
        }

        // PUT: desativar adicional
        [HttpPut("{id}/desativar")]
        public IActionResult Desativar(int id)
        {
            var adicional = _context.Adicionais.Find(id);

            if (adicional == null)
                return NotFound("Adicional não encontrado.");

            adicional.Ativo = false;
            _context.SaveChanges();

            return Ok("Adicional desativado com sucesso.");
        }
    }
}