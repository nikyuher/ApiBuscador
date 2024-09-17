using Microsoft.EntityFrameworkCore;
using Buscador.Models;

namespace Buscador.Data
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly BuscadorContext _context;

        public CiudadRepository(BuscadorContext context)
        {
            _context = context;
        }

        public List<Ciudad> GetAll()
        {
            var ciudades = _context.Ciudadades.ToList();

            return ciudades;
        }
    }
}

