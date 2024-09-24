using Buscador.Models;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Buscador.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BuscadorContext _context;

        public UsuarioRepository(BuscadorContext context)
        {
            _context = context;
        }

        public List<UsuarioDTO> GetAll()
        {
            var usuarios = _context.Usuarios.Include(p => p.Peticiones).ToList();

            var usuarioDTOs = usuarios.Select(usuario => new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Rol = usuario.Rol,
                PeticionesDTO = usuario.Peticiones.Select(peticion => new PeticionDTO
                {
                    IdPeticion = peticion.IdPeticion,
                    NombreEmpresa = peticion.NombreEmpresa,
                    DescripcionEmpresa = peticion.DescripcionEmpresa,
                    DireccionEmpresa = peticion.DireccionEmpresa,
                    ImagenEmpresaURL = peticion.ImagenEmpresaURL,
                    IdCategoriaEmpresa = peticion.IdCategoriaEmpresa,
                    IdCiudadEmpresa = peticion.IdCiudadEmpresa
                }).ToList()
            }).ToList();

            return usuarioDTOs;
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

