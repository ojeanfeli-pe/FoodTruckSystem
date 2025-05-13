using Microsoft.EntityFrameworkCore;                     // Usado para configurar o banco de dados
using QueijoMoreno.Api.Data;                            // Usado para acessar o AppDbContext

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// Configuração dos serviços da aplicação
// ----------------------------------------------------

// Adiciona o suporte para controladores de API (Controllers)
builder.Services.AddControllers();

// Configura o Entity Framework com banco SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=queijomoreno.db"));

// (Opcional) Adiciona documentação Swagger para testes da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------------------------------------
// Configuração do pipeline de requisições HTTP
// ----------------------------------------------------

// Se estiver em ambiente de desenvolvimento, ativa o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona HTTP para HTTPS automaticamente
app.UseHttpsRedirection();

// Usa o sistema de autorização (não configurado por padrão)
app.UseAuthorization();

// Mapeia os controllers (rotas como /api/produto, /api/cliente, etc.)
app.MapControllers();

// Inicia a aplicação
app.Run();
