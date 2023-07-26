using SiteLanches.Models;
using Microsoft.EntityFrameworkCore;


namespace SiteLanches.Context
{
    public class AppDbContext   : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}
    