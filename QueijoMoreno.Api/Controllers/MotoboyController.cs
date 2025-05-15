using Microsoft.AspNetCore.Mvc;
using QueijoMoreno.Api.Data;
using QueijoMoreno.Api.Models;

namespace QueijoMoreno.Api.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoboyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotoboyController(AppDbContext context){
            _context = context;
        }

        //POST: CADASTRAR MOTOBOY
        [HttpPost]
        public IActionResult Post([FromBody] Motoboy motoboy){
            _context.Motoboys.Add(motoboy);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = motoboy.Id}, motoboy);
        }

        //GET: BUSCAR OS MOTOBOYS ATIVOS
        [HttpGet]
         public IActionResult Get(){
             
             var motoboys = _context.Motoboys
                .Where(m => m.Ativo)
                .ToList();

            return Ok(motoboys);
        }
        // GET: Buscar por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var motoboy = _context.Motoboys.Find(id);

            if (motoboy == null)
                return NotFound("Motoboy não encontrado.");

            return Ok(motoboy);
        }

        // PUT: Desativar motoboy
        [HttpPut("{id}/desativar")]
        public IActionResult Desativar(int id)
        {
            var motoboy = _context.Motoboys.Find(id);

            if (motoboy == null)
                return NotFound("Motoboy não encontrado.");

            motoboy.Ativo = false;
            _context.SaveChanges();

            return Ok("Motoboy desativado com sucesso.");
        }
    }
}