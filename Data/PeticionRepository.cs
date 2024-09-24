using Buscador.Models;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Buscador.Data
{
    public class PeticionRepository : IPeticionRepository
    {
        private readonly BuscadorContext _context;

        public PeticionRepository(BuscadorContext context)
        {
            _context = context;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

