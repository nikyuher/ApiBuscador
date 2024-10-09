using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IEmailService emailService)
        {
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
        }


        //Get
        public List<UsuarioDTO> GetAll() => _usuarioRepository.GetAll();
        public UsuarioDTO GetUsuarioId(int id)
        {
            return _usuarioRepository.GetUsuarioId(id);
        }
        public PeticionesUsuarioDTO GetPeticionesUsuarioId(int id)
        {
            return _usuarioRepository.GetPeticionesUsuarioId(id);
        }
        public EmpresasUsuarioDTO GetEmpresasUsuarioId(int id)
        {
            return _usuarioRepository.GetEmpresasUsuarioId(id);
        }
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO)
        {
            return _usuarioRepository.LoginUsuario(loginDTO);
        }

        //Create
        public Usuario RegisterUsuario(RegisterUsuarioDTO user)
        {
            return _usuarioRepository.RegisterUsuario(user);
        }

        //Update
        public void UpdateUsuario(PutUsuarioDTO usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }

        public void CambiarContrasena(int idUsuario, CambiarContrasenaDTO request)
        {
            _usuarioRepository.CambiarContrasena(idUsuario, request);
        }

        //Delete
        public void DeleteUsuario(int idUsuario)
        {
            _usuarioRepository.DeleteUsuario(idUsuario);
        }

        public void DeleteEmpresaUsuario(int empresaUsuario)
        {
            _usuarioRepository.DeleteEmpresaUsuario(empresaUsuario);

        }

        //Email

        public async Task SolicitarRecuperacionAsync(SolicitarRecuperacionDTO request)
        {
            try
            {
                var usuario = await _usuarioRepository.ObtenerUsuarioPorCorreoAsync(request.Correo);
                if (usuario == null)
                {
                    throw new ArgumentException("Usuario no encontrado.");
                }

                // Generar código de recuperación de 5 dígitos
                var codigoRecuperacion = new Random().Next(10000, 99999).ToString();

                // Establecer el código y su expiración (por ejemplo, 15 minutos)
                var expiracion = DateTime.UtcNow.AddMinutes(15);
                await _usuarioRepository.EstablecerCodigoRecuperacionAsync(request.Correo, codigoRecuperacion, expiracion);

                // Enviar el código por correo
                var asunto = "Recuperación de Contraseña";
                var cuerpo = $"Hola {usuario.Nombre},\n\nTu código de recuperación de contraseña es: {codigoRecuperacion}\nEste código expirará en 15 minutos.\n\nSi no solicitaste esta recuperación, por favor ignora este correo.";
                await _emailService.EnviarCorreoAsync(usuario.Correo, asunto, cuerpo);
            }
            catch (Exception ex)
            {
                var usuario = await _usuarioRepository.ObtenerUsuarioPorCorreoAsync(request.Correo);
                if (usuario == null)
                {
                    throw new ArgumentException("Usuario no encontrado.");
                }
                throw new Exception($"Error al solicitar recuperación para {request.Correo} correo buscado {usuario.Correo}: {ex.Message}", ex);
            }
        }


        public async Task CambiarContrasenaConCodigoAsync(RestablecerContrasenaDTO request)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorCorreoAsync(request.Correo);
            if (usuario == null)
            {
                throw new ArgumentException("Usuario no encontrado.");
            }

            if (usuario.PasswordResetCode != request.Codigo || usuario.PasswordResetCodeExpiry < DateTime.UtcNow)
            {
                throw new ArgumentException("Código de recuperación inválido o expirado.");
            }

            // Verificar que la nueva contraseña y su confirmación coincidan
            if (request.NuevaContrasena != request.ConfirmarContrasena)
            {
                throw new ArgumentException("Las contraseñas no coinciden.");
            }

            // Restablecer la contraseña
            await _usuarioRepository.RestablecerContrasenaAsync(request.Correo, request.NuevaContrasena);
        }
    }
}
