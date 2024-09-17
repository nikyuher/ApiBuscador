using Microsoft.EntityFrameworkCore;
using Buscador.Models;

namespace Buscador.Data
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly BuscadorContext _context;

        public CategoriaRepository(BuscadorContext context)
        {
            _context = context;
        }

        public List<Categoria> GetAll()
        {
            var empresas = _context.Categorias.ToList();

            return empresas;
        }
    }
}

