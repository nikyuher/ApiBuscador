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
                Correo = usuario.Correo,
                Rol = usuario.Rol
            }).ToList();

            return usuarioDTOs;
        }

        public UsuarioDTO GetUsuarioId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);


            if (usuario is null)
            {
                throw new Exception($"No hay ningun usuario con el ID: {id}");
            }

            var usuarioDTOs = new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol,
            };

            return usuarioDTOs;
        }

        public PeticionesUsuarioDTO GetPeticionesUsuarioId(int id)
        {
            var usuario = _context.Usuarios.Include(p => p.Peticiones).FirstOrDefault(u => u.IdUsuario == id);


            if (usuario is null)
            {
                throw new Exception($"No hay ningun usuario con el ID: {id}");
            }

            var usuarioDTOs = new PeticionesUsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
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

        public EmpresasUsuarioDTO GetEmpresasUsuarioId(int id)
        {
            var usuario = _context.Usuarios
                         .Include(p => p.MisEmpresas)
                           .ThenInclude(ue => ue.Empresa)
                         .FirstOrDefault(u => u.IdUsuario == id);


            if (usuario is null)
            {
                throw new Exception($"No hay ningun usuario con el ID: {id}");
            }

            var usuarioDTOs = new EmpresasUsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                MisEmpresas = usuario.MisEmpresas.Select(empresa => new UsuarioEmpresaDTO
                {
                    IdUsuarioEmpresa = empresa.IdUsuarioEmpresa,
                    IdEmpresa = empresa.IdEmpresa,
                    Empresa = new DatosEmpresaDTO
                    {
                        IdEmpresa = empresa.Empresa.IdEmpresa,
                        Nombre = empresa.Empresa.Nombre,
                        Descripcion = empresa.Empresa.Descripcion,
                        Direccion = empresa.Empresa.Direccion,
                        Telefono = empresa.Empresa.Telefono,
                        CorreoEmpresa = empresa.Empresa.CorreoEmpresa,
                        SitioWeb = empresa.Empresa.SitioWeb,
                        Imagen = empresa.Empresa.Imagen
                    }
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

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == loginDTO.Correo);

            if (usuario is null)
            {
                throw new InvalidOperationException("Correo Inconrrecto.");
            }

            // Verificar la contraseña
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDTO.Contrasena, usuario.Contrasena);
            if (!isPasswordValid)
            {
                throw new InvalidOperationException("Contraseña Incorrecto.");
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

            // Hashear la contraseña
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Contrasena);

            var newUser = new Usuario
            {
                Nombre = user.Nombre,
                Contrasena = hashedPassword, // Almacenar el hash
                Correo = user.Correo,
                Rol = false,
                PasswordChangedAt = DateTime.UtcNow
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

            if (usuario.Correo != existingUser.Correo &&
                _context.Usuarios.Any(u => u.Correo == usuario.Correo))
            {
                throw new ArgumentException("El correo electrónico ya está en uso por otro usuario.");
            }
            existingUser.Nombre = usuario.Nombre;
            existingUser.Correo = usuario.Correo;

            _context.Usuarios.Update(existingUser);
            SaveChanges();
        }

        public void CambiarContrasena(int idUsuario, CambiarContrasenaDTO request)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado.");
            }

            // Verificar que la nueva contraseña y la confirmación coincidan

            if (request.NuevaContrasena != request.ConfirmarContrasena)
            {
                throw new ArgumentException("La confirmación de la nueva contraseña no coincide.");
            }

            // Hashear la nueva contraseña
            string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(request.NuevaContrasena);
            usuario.Contrasena = hashedNewPassword;
            usuario.PasswordChangedAt = DateTime.UtcNow;

            _context.Usuarios.Update(usuario);
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

        public void DeleteEmpresaUsuario(int idUsuarioEmpresa)
        {

            var existingEmpresa = _context.UsuarioEmpresas.FirstOrDefault(ue => ue.IdUsuarioEmpresa == idUsuarioEmpresa);

            if (existingEmpresa is null)
            {
                throw new Exception($"La empresa ya no esta asosciada a este usuario");
            }


            var empresaExisting = _context.Empresas.FirstOrDefault(e => e.IdEmpresa == existingEmpresa.IdEmpresa);

            if (empresaExisting is null)
            {
                throw new Exception($"La empresa fue eliminada antes de estar en el usuario");
            }

            _context.Empresas.Remove(empresaExisting);
            _context.UsuarioEmpresas.Remove(existingEmpresa);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        //Email

        public async Task EstablecerCodigoRecuperacionAsync(string correo, string codigo, DateTime expiracion)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
                if (usuario != null)
                {
                    usuario.PasswordResetCode = codigo;
                    usuario.PasswordResetCodeExpiry = expiracion;
                    _context.Usuarios.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Usuario no encontrado.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Manejo específico de errores de actualización de base de datos
                throw new Exception("Error al actualizar el usuario en la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                // Manejo genérico de excepciones
                throw new Exception("Ocurrió un error al establecer el código de recuperación.", ex);
            }
        }

        public async Task<Usuario?> ObtenerUsuarioPorCorreoAsync(string correo)
        {
            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el usuario por correo.", ex);
            }
        }

        public async Task RestablecerContrasenaAsync(string correo, string nuevaContrasena)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
                if (usuario != null)
                {
                    usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);
                    usuario.PasswordChangedAt = DateTime.UtcNow;
                    usuario.PasswordResetCode = null;
                    usuario.PasswordResetCodeExpiry = null;
                    _context.Usuarios.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Usuario no encontrado.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Manejo específico de errores de actualización de base de datos
                throw new Exception("Error al restablecer la contraseña en la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                // Manejo genérico de excepciones
                throw new Exception("Ocurrió un error al restablecer la contraseña.", ex);
            }
        }

    }
}

