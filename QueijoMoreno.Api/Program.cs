using Microsoft.EntityFrameworkCore;
using QueijoMoreno.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=queijomoreno.db"));
