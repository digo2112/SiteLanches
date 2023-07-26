using SiteLanches.Models;
using SiteLanches.Context;
using SiteLanches.Repositories.Interfaces;

namespace SiteLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
