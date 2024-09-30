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

        //Get
        public List<UsuarioDTO> GetAll()
        {
            var usuarios = _context.Usuarios.ToList();

            var usuarioDTOs = usuarios.Select(usuario => new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Rol = usuario.Rol
            }).ToList();

            return usuarioDTOs;
        }

        public UsuarioDTO GetUsuarioId(int id)
        {
            var usuario = _context.Usuarios.Include(p => p.Peticiones).FirstOrDefault(u => u.IdUsuario == id);


            if (usuario is null)
            {
                throw new Exception($"No hay ningun usuario con el ID: {id}");
            }

            var usuarioDTOs = new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Rol = usuario.Rol,
                PeticionesDTO = usuario.Peticiones.Select(peticion => new PeticionDTO
                {
                    IdPeticion = peticion.IdPeticion,
                    IdUsuario = peticion.IdUsuario,
                    NombreEmpresa = peticion.NombreEmpresa,
                    DescripcionEmpresa = peticion.DescripcionEmpresa,
                    DireccionEmpresa = peticion.DireccionEmpresa,
                    ImagenEmpresaURL = peticion.ImagenEmpresaURL,
                    IdCategoriaEmpresa = peticion.IdCategoriaEmpresa,
                    IdCiudadEmpresa = peticion.IdCiudadEmpresa
                }).ToList()
            };

            return usuarioDTOs;
        }

        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO)
        {
            if (string.IsNullOrWhiteSpace(loginDTO.Correo))
            {
                throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(loginDTO.Correo));
            }

            if (string.IsNullOrWhiteSpace(loginDTO.Contrasena))
            {
                throw new ArgumentException("La contraseña no puede estar vacía", nameof(loginDTO.Contrasena));
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == loginDTO.Correo && u.Contrasena == loginDTO.Contrasena);

            if (usuario is null)
            {
                throw new InvalidOperationException("Usuario o Correo Incorrecto");
            }

            return usuario;
        }

        //Create
        public Usuario RegisterUsuario(RegisterUsuarioDTO user)
        {

            if (_context.Usuarios.Any(u => u.Correo == user.Correo))
            {
                throw new ArgumentException("El correo electrónico ya está en uso.");
            }

            if (_context.Usuarios.Any(u => u.Contrasena == user.Contrasena))
            {
                throw new ArgumentException("La contraseña ya esta en uso.");
            }

            var newUser = new Usuario
            {
                Nombre = user.Nombre,
                Contrasena = user.Contrasena,
                Correo = user.Correo,
                Rol = false
            };

            _context.Usuarios.Add(newUser);
            SaveChanges();

            return newUser;
        }

        //Update

        public void UpdateUsuario(PutUsuarioDTO usuario)
        {
        var existingUser = _context.Usuarios.Find(usuario.IdUsuario);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
        }

        existingUser.Nombre = usuario.Nombre;
        existingUser.Contrasena = usuario.Contrasena;
        existingUser.Correo = usuario.Correo;

        _context.Usuarios.Update(existingUser);
        SaveChanges();
        }

        //Delete

        public void DeleteUsuario(int idUsuario)
        {
            var usuario = _context.Usuarios.FirstOrDefault(r => r.IdUsuario == idUsuario);

            if (usuario is null)
            {
                throw new Exception($"No se encontro el Usuario con el ID: {idUsuario}");
            }

            _context.Usuarios.Remove(usuario);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

