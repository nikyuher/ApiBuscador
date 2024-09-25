using Microsoft.AspNetCore.Mvc;
using Buscador.Models;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Get
        [HttpGet]
        public ActionResult<List<UsuarioDTO>> GetAll()
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }

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

        [HttpGet("login", Name = "LoginUsuario")]
        public ActionResult<Usuario> LoginUsuario([FromQuery] LoginUsuarioDTO loginUsuario)
        {

            try
            {

                var usuario = _usuarioService.LoginUsuario(loginUsuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Post
        [HttpPost(Name = "RegisterUsuario")]

        public ActionResult RegisterUsuario([FromBody] RegisterUsuarioDTO user)
        {

            try
            {

                var usuario = _usuarioService.RegisterUsuario(user);
                return Ok(usuario);
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
