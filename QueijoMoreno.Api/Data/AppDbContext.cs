using Microsoft.EntityFrameworkCore;
using QueijoMoreno.Api.Models;


namespace QueijoMoreno.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos {get;set;}
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Pedido> Pedidos {get;set;}
        public DbSet<ItemPedido> ItensPedido {get;set;}
        public DbSet<TaxaEntrega> TaxasEntrega {get;set;}
        public DbSet<Motoboy> Motoboys {get;set;}
    }
}