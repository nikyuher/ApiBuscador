using Buscador.Models;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

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
            var suscripciones = await _context.Suscripciones.ToListAsync();

            var newListSubs = suscripciones.Select(s => new SuscripcionDTO
            {
                IdSuscripcion = s.IdSuscripcion,
                TipoPlan = s.TipoPlan,
                Descripcion = s.Descripcion,
                Costo = s.Costo
            }).ToList();

            return newListSubs;

        }

        public async Task<UsuarioTipoSuscripcionDTO> GetUsuariosSuscritosPlan(int IdSuscripcion)
        {

            var suscripcion = await _context.Suscripciones.Include(u => u.UsuarioSuscripciones).FirstOrDefaultAsync(s => s.IdSuscripcion == IdSuscripcion);

            if (suscripcion is null)
            {
                throw new Exception($"No hay ninguna suscripcion con el ID: {IdSuscripcion}");
            }

            var newSuscripcion = new UsuarioTipoSuscripcionDTO
            {
                IdSuscripcion = suscripcion.IdSuscripcion,
                TipoPlan = suscripcion.TipoPlan,
                UsuarioSuscripciones = suscripcion.UsuarioSuscripciones.Select(us => new UsuarioSuscripcionDTO
                {
                    IdUsuarioSuscripcion = us.IdUsuarioSuscripcion,
                    Usuario = new PutUsuarioDTO
                    {
                        IdUsuario = us.Usuario.IdUsuario,
                        Nombre = us.Usuario.Nombre,
                        Correo = us.Usuario.Correo
                    },
                    FechaInicio = us.FechaInicio,
                    FechaExpiracion = us.FechaExpiracion,
                    DuracionMeses = us.DuracionMeses,
                    EsActiva = us.EsActiva
                }).ToList()
            };

            return newSuscripcion;
        }

        //Post
        public async Task<Suscripcion> Create(SuscripcionDatosDTO datos)
        {

            var newSuscripcion = new Suscripcion
            {
                TipoPlan = datos.TipoPlan,
                Descripcion = datos.Descripcion,
                Costo = datos.Costo
            };

            await _context.Suscripciones.AddAsync(newSuscripcion);
            await _context.SaveChangesAsync();

            return newSuscripcion;
        }

        public async Task AñadirSuscripcionUser(AddUsuarioSuscripcionDTO datos)
        {
            var existingSuscripcion = await _context.Suscripciones.FindAsync(datos.SuscripcionId);
            var existingUser = await _context.Usuarios.FindAsync(datos.UsuarioId);

            if (existingSuscripcion == null)
            {
                throw new Exception("La suscripción no existe.");
            }

            if (existingUser == null)
            {
                throw new Exception("El usuario no existe.");
            }

            var fechaExpiracion = datos.FechaInicio.AddMonths(datos.DuracionMeses);

            var newUsuarioSuscripcion = new UsuarioSuscripcion
            {
                UsuarioId = datos.UsuarioId,
                SuscripcionId = datos.SuscripcionId,
                FechaInicio = datos.FechaInicio,
                FechaExpiracion = fechaExpiracion,
                EsActiva = datos.FechaInicio <= DateTime.Now && fechaExpiracion >= DateTime.Now
            };

            await _context.UsuarioSuscripciones.AddAsync(newUsuarioSuscripcion);
            await _context.SaveChangesAsync();
        }

        //Update

        public async Task<Suscripcion> UpdateDatos(SuscripcionDatosDTO datos)
        {
            var existingSuscripcion = await _context.Suscripciones.FindAsync(datos.IdSuscripcion);

            if (existingSuscripcion == null)
            {
                throw new Exception("La suscripción no existe.");
            }

            existingSuscripcion.TipoPlan = datos.TipoPlan;
            existingSuscripcion.Descripcion = datos.Descripcion;
            existingSuscripcion.Costo = datos.Costo;

            await _context.SaveChangesAsync();

            return existingSuscripcion;
        }

        //Delete

        public async Task<Suscripcion> Delete(int IdSuscripcion)
        {
            var existingSuscripcion = await _context.Suscripciones.FindAsync(IdSuscripcion);

            if (existingSuscripcion == null)
            {
                throw new Exception("La suscripción no existe.");
            }

            _context.Suscripciones.Remove(existingSuscripcion);

            await _context.SaveChangesAsync();

            return existingSuscripcion;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

