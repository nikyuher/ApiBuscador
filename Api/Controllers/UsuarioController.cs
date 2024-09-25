using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Buscador.Models;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthService _authService;

        public UsuarioController(IUsuarioService usuarioService, IAuthService authService)
        {
            _usuarioService = usuarioService;
            _authService = authService;
        }

        // Get
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<UsuarioDTO>> GetAll()
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{idUsuario}", Name = "GetUsuarioId")]

        public ActionResult<UsuarioDTO> GetUsuarioId([FromRoute] int idUsuario)
        {
            try
            {

                var usuario = _usuarioService.GetUsuarioId(idUsuario);

                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("login", Name = "LoginUsuario")]
        public ActionResult<Usuario> LoginUsuario([FromQuery] LoginUsuarioDTO loginUsuario)
        {

            try
            {

                var usuario = _usuarioService.LoginUsuario(loginUsuario);
                var token = _authService.GenerateJwtToken(usuario);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Post
        [AllowAnonymous]
        [HttpPost(Name = "RegisterUsuario")]

        public ActionResult RegisterUsuario([FromBody] RegisterUsuarioDTO user)
        {

            try
            {

                var usuario = _usuarioService.RegisterUsuario(user);
                var token = _authService.GenerateJwtToken(usuario);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Update

        [HttpPut(Name = "UpdateUsuario")]

        public ActionResult UpdateUsuario([FromBody] UsuarioDTO usuario)
        {

            try
            {

                _usuarioService.UpdateUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete("{idUsuario}", Name = "DeleteUsuario")]

        public ActionResult DeleteUsuario([FromRoute] int idUsuario)
        {

            try
            {

                _usuarioService.DeleteUsuario(idUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
