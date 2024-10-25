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
                    Nombre = peticion.Usuario?.Nombre,
                    Correo = peticion.Usuario?.Correo
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

            if (_context.Empresas.Any(e => e.Nombre == peticionDTO.NombreEmpresa))
            {
                throw new Exception($"Ya existe una empresa con el nombre {peticionDTO.NombreEmpresa}");
            }

            if (!_context.Categorias.Any(e => e.IdCategoria == peticionDTO.IdCategoriaEmpresa))
            {
                throw new Exception($"No existe una categoria con el ID: {peticionDTO.IdCategoriaEmpresa}");
            }

            if (!_context.Ciudadades.Any(e => e.IdCiudad == peticionDTO.IdCiudadEmpresa))
            {
                throw new Exception($"No existe una ciudad con el ID: {peticionDTO.IdCiudadEmpresa}");
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

        public async Task AceptarPeticionAsync(int idPeticion)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var peticion = await _context.Peticiones.FirstOrDefaultAsync(p => p.IdPeticion == idPeticion);

                    if (peticion == null)
                    {
                        throw new Exception($"No existe la peticion con el ID: {idPeticion} ");
                    }

                    if (await _context.Empresas.AnyAsync(e => e.Nombre == peticion.NombreEmpresa))
                    {
                        throw new Exception($"Ya existe una empresa con el nombre {peticion.NombreEmpresa}");
                    }

                    if (!await _context.Categorias.AnyAsync(e => e.IdCategoria == peticion.IdCategoriaEmpresa))
                    {
                        throw new Exception($"No existe una categoria con el ID: {peticion.IdCategoriaEmpresa}");
                    }

                    if (!await _context.Ciudadades.AnyAsync(e => e.IdCiudad == peticion.IdCiudadEmpresa))
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

                    // Agregamos la nueva empresa
                    await _context.Empresas.AddAsync(nuevaEmpresa);
                    await _context.SaveChangesAsync(); // Guardamos para obtener el Id de la nueva empresa

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

                    var newUsuarioEmpresa = new UsuarioEmpresa
                    {
                        IdUsuario = peticion.IdUsuario,
                        IdEmpresa = nuevaEmpresa.IdEmpresa
                    };

                    // Eliminamos la petición
                    DeletePeticion(idPeticion);

                    // Agregamos las relaciones
                    await _context.EmpresaCategorias.AddAsync(newCategoriaEmpresa);
                    await _context.EmpresasCiudades.AddAsync(newCiudadEmpresa);
                    await _context.UsuarioEmpresas.AddAsync(newUsuarioEmpresa);

                    // Guardamos todos los cambios
                    await _context.SaveChangesAsync();

                    // Confirmamos la transacción
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Si ocurre algún error, revertimos los cambios
                    await transaction.RollbackAsync();
                    throw new Exception($"Ocurrio un error: {ex}");
                }
            }
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

