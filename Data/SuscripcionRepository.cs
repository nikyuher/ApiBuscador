using Buscador.Models;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Buscador.Data
{
    public class SuscripcionRepository : ISuscripcionRepository
    {
        private readonly BuscadorContext _context;

        public SuscripcionRepository(BuscadorContext context)
        {
            _context = context;
        }

        //Get

        public async Task<List<SuscripcionDTO>> GetAll()
        {
            var suscripciones = await _context.Suscripciones.Include(u => u.Usuario).ToListAsync();

            var newListSubs = suscripciones.Select(s => new SuscripcionDTO
            {
                IdSuscripcion = s.IdSuscripcion,
                UsuarioNombre = s.Usuario.Nombre,
                TipoPlan = s.TipoPlan,
                FechaInicio = s.FechaInicio,
                FechaExpiracion = s.FechaExpiracion,
                Costo = s.Costo
            }).ToList();

            return newListSubs;

        }

        // public async Task<SuscripcionDTO> Get

        //Post
        //Update
        //Delete

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

