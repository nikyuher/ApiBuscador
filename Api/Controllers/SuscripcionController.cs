using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Buscador.Models;
using Buscador.Business;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace Buscador.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SuscripcionController : ControllerBase
    {
        private readonly ISuscripcionService _suscripcionService;
        private readonly IAuthService _authService;
        private readonly ILogger<SuscripcionController> _logger;

        public SuscripcionController(ISuscripcionService suscripcionService, IAuthService authService, ILogger<SuscripcionController> logger)
        {
            _suscripcionService = suscripcionService;
            _logger = logger;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await _suscripcionService.GetAll();
                _logger.LogInformation($"Se solicito la lista de suscripciones");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la lista: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("usuarios/plan", Name = "GetUsuariosSuscritosPlan")]
        public async Task<IActionResult> GetUsuariosSuscritosPlan(int IdSuscripcion)
        {
            try
            {
                var lista = await _suscripcionService.GetUsuariosSuscritosPlan(IdSuscripcion);
                _logger.LogInformation($"Se solicito la lista de usuarios suscritos al id: {IdSuscripcion}");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la lista: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Post

        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreatePlanSuscripcion")]
        public async Task<IActionResult> Create([FromBody] SuscripcionDatosDTO datos)
        {
            try
            {
                var suscripcion = await _suscripcionService.Create(datos);
                _logger.LogInformation($"Se creado un nuevo plan de suscripcion");
                return Ok(suscripcion);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear un nuevo plan de suscripcion: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("comprar-plan", Name = "AñadirSuscripcionUser")]
        public async Task<IActionResult> AñadirSuscripcionUser([FromBody] AddUsuarioSuscripcionDTO datos)
        {
            try
            {
                var currentUser = HttpContext.User;

                if (!_authService.HasAccessToResource(currentUser, datos.UsuarioId))
                {
                    _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para comprar una suscripcion al usuario con ID: {datos.UsuarioId}.");
                    return Forbid();
                }

                await _suscripcionService.AñadirSuscripcionUser(datos);
                _logger.LogInformation($"El usuario con ID : {datos.UsuarioId} compro un plan de suscripcion con ID: {datos.SuscripcionId} con un tiempo de {datos.DuracionMeses} meses");
                return Ok(new { message = "Plan de suscripcion comprada correctamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al comprar el plan de suscripcion: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Put
        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "UpdateDatos")]
        public async Task<IActionResult> UpdateDatos([FromBody] SuscripcionDatosDTO datos)
        {
            try
            {
                var suscripcion = await _suscripcionService.UpdateDatos(datos);
                _logger.LogInformation($"Se solicito actualizar datos de la suscripcion con ID. {datos.IdSuscripcion}");
                return Ok(suscripcion);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar los datos del plan de suscripcion con ID:{datos.IdSuscripcion}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Delete 
        [Authorize(Roles = "Admin")]
        [HttpDelete(Name = "DeleteSuscripcion")]
        public async Task<IActionResult> Delete(int IdSuscripcion)
        {
            try
            {
                var suscripcion = await _suscripcionService.Delete(IdSuscripcion);
                _logger.LogInformation($"Se solicito eliminar la suscripcion con ID. {IdSuscripcion}");
                return Ok(suscripcion);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la suscripcion con ID:{IdSuscripcion}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
