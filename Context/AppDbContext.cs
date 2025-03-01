using ApiLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLoja.Context

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }        
        public DbSet<Carrinho> Carrinhos { get; set; }

        public DbSet<CarrinhoProdutos> CarrinhoProdutos { get; set; }   


    }
}
