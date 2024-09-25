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

        //Get
        public List<PeticionDTO> GetAll()
        {
            var peticiones = _context.Peticiones
                .Include(p => p.Usuario)
                .ToList();

            var newPeticiones = peticiones.Select(peticion => new PeticionDTO
            {
                IdPeticion = peticion.IdPeticion,
                IdUsuario = peticion.IdUsuario,
                DatosUsuario = new DatosUsuarioDTO
                {
                    Nombre = peticion.Usuario.Nombre,
                    Correo = peticion.Usuario.Correo
                },
                NombreEmpresa = peticion.NombreEmpresa,
                DescripcionEmpresa = peticion.DescripcionEmpresa,
                DireccionEmpresa = peticion.DireccionEmpresa,
                ImagenEmpresaURL = peticion.ImagenEmpresaURL,
                IdCategoriaEmpresa = peticion.IdCategoriaEmpresa,
                IdCiudadEmpresa = peticion.IdCiudadEmpresa
            }).ToList();

            return newPeticiones;
        }

        //Post

        public AddPeticionDTO AddPeticion(AddPeticionDTO peticionDTO)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.IdUsuario == peticionDTO.IdUsuario);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var nuevaPeticion = new Peticion
            {
                NombreEmpresa = peticionDTO.NombreEmpresa,
                DescripcionEmpresa = peticionDTO.DescripcionEmpresa,
                DireccionEmpresa = peticionDTO.DireccionEmpresa,
                ImagenEmpresaURL = peticionDTO.ImagenEmpresaURL,
                IdCategoriaEmpresa = peticionDTO.IdCategoriaEmpresa,
                IdCiudadEmpresa = peticionDTO.IdCiudadEmpresa,
                IdUsuario = usuario.IdUsuario
            };

            _context.Peticiones.Add(nuevaPeticion);

            _context.SaveChanges();

            return peticionDTO;
        }

        public void AceptarPeticion(int idPeticion)
        {
            var peticion = _context.Peticiones.FirstOrDefault(p => p.IdPeticion == idPeticion);

            if (peticion == null)
            {
                throw new Exception($"No existe la peticion con el ID: {idPeticion} ");
            }

            if (_context.Empresas.Any(e => e.Nombre == peticion.NombreEmpresa))
            {
                throw new Exception($"Ya existe una empresa con el nombre {peticion.NombreEmpresa}");
            }

            if (_context.EmpresaCategorias.Any(e => e.IdCategoria == peticion.IdCategoriaEmpresa))
            {
                throw new Exception($"No existe una categoria con el ID: {peticion.IdCategoriaEmpresa}");
            }

            if (_context.EmpresasCiudades.Any(e => e.IdCiudad == peticion.IdCiudadEmpresa))
            {
                throw new Exception($"No existe una ciudad con el ID: {peticion.IdCiudadEmpresa}");
            }

            var nuevaEmpresa = new Empresa
            {
                Nombre = peticion.NombreEmpresa,
                Descripcion = peticion.DescripcionEmpresa,
                Direccion = peticion.DireccionEmpresa,
                Imagen = peticion.ImagenEmpresaURL

            };

            _context.Empresas.Add(nuevaEmpresa);
            _context.SaveChanges();

            var newCategoriaEmpresa = new EmpresaCategoria
            {
                IdCategoria = peticion.IdCategoriaEmpresa,
                IdEmpresa = nuevaEmpresa.IdEmpresa
            };

            var newCiudadEmpresa = new EmpresaCiudad
            {
                IdCiudad = peticion.IdCiudadEmpresa,
                IdEmpresa = nuevaEmpresa.IdEmpresa
            };

            DeletePeticion(idPeticion);

            _context.EmpresaCategorias.Add(newCategoriaEmpresa);
            _context.EmpresasCiudades.Add(newCiudadEmpresa);
            _context.SaveChanges();
        }

        //Delete 

        public void DeletePeticion(int idPeticion)
        {

            var peticion = _context.Peticiones.FirstOrDefault(p => p.IdPeticion == idPeticion);

            if (peticion is null)
            {
                throw new Exception($"No se encontro la peticion con el ID: {idPeticion}");
            }

            _context.Peticiones.Remove(peticion);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

