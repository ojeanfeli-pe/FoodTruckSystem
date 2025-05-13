using Microsoft.AspNetCore.Mvc;
using QueijoMoreno.Api.Data;
using QueijoMoreno.Api.Models;

namespace QueijoMoreno.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/produto
        [HttpGet]
       public IActionResult Get(){
        var produto = _context.Produtos.ToList();
        return Ok(produto);
       }

       [HttpPost]
       public IActionResult Post([FromBody] Produto produto)
       {
           _context.Produtos.Add(produto);
           _context.SaveChanges();

           return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
       }
    }
}