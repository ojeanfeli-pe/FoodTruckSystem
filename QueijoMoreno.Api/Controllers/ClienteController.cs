// Importa os namespaces necessários
using Microsoft.AspNetCore.Mvc; // Para criar a API e os controladores
using QueijoMoreno.Api.Data;    // Acesso ao banco de dados (AppDbContext)
using QueijoMoreno.Api.Models;  // Acesso ao modelo Cliente

namespace QueijoMoreno.Api.Controllers
{
    // Indica que esta classe é um Controller de API
    [ApiController]

    // Define a rota base da URL para este controller: /api/cliente
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        // Campo privado para acessar o banco de dados
        private readonly AppDbContext _context;

        // Construtor: recebe o contexto do banco via injeção de dependência
        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // Método GET que recebe um número de telefone como parâmetro
        // Ex: GET /api/cliente/11988887777
        [HttpGet("{telefone}")]
        public IActionResult GetByTelefone(string telefone)
        {
            // Procura no banco um cliente com o telefone informado
            var cliente = _context.Clientes.FirstOrDefault(c => c.Telefone == telefone);

            // Se não encontrar, retorna 404 (não encontrado)
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            // Se encontrar, retorna 200 OK com os dados do cliente
            return Ok(cliente);
        }

        // Método POST para cadastrar um novo cliente
        // Espera os dados do cliente no corpo da requisição (JSON)
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            // Adiciona o cliente ao banco
            _context.Clientes.Add(cliente);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();

            // Retorna resposta 201 Created com a URL de acesso ao cliente recém-criado
            return CreatedAtAction(nameof(GetByTelefone), new { telefone = cliente.Telefone }, cliente);
        }
    }
}
