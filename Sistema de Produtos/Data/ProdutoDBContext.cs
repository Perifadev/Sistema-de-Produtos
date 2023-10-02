using Microsoft.EntityFrameworkCore;
using Sistema_de_Produtos.Model;

namespace Sistema_de_Produtos.Data
{
    public class ProdutoDBContext : DbContext 
    {
        public ProdutoDBContext(DbContextOptions<ProdutoDBContext> options) 
                : base(options)
        {
        }

        public DbSet<Produtos> Produtos {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
