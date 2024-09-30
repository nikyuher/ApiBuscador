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
    public class PeticionController : ControllerBase
    {
        private readonly IPeticionService _peticionService;

        private readonly IAuthService _authService;
        private readonly ILogger<PeticionController> _logger;

        public PeticionController(IPeticionService peticionService, IAuthService authService, ILogger<PeticionController> logger)
        {
            _peticionService = peticionService;
            _authService = authService;
            _logger = logger;
        }

        // Get
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<PeticionDTO>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitud para obtener todas las peticiones.");
                var peticiones = _peticionService.GetAll();
                return Ok(peticiones);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todas las peticiones: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Post
        [HttpPost(Name = "AddPeticion")]
        public ActionResult AddPeticion([FromBody] AddPeticionDTO peticionDTO)
        {
            try
            {
                _logger.LogInformation("Solicitud para agregar una nueva petición.");

                // Verificar si el usuario tiene acceso al recurso
                var currentUser = HttpContext.User;
                if (!_authService.HasAccessToResource(currentUser, peticionDTO.IdUsuario))
                {
                    _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {peticionDTO.IdUsuario}.");
                    return Forbid();
                }

                var peticion = _peticionService.AddPeticion(peticionDTO);
                _logger.LogInformation($"Petición agregada con éxito.");
                return Ok(peticion);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al agregar petición: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("validar", Name = "AceptarPeticion")]
        public ActionResult AceptarPeticion(int peticionId)
        {
            try
            {
                _logger.LogInformation($"Solicitud para aceptar la petición con ID: {peticionId}");
                _peticionService.AceptarPeticion(peticionId);
                _logger.LogInformation($"Petición con ID: {peticionId} aceptada exitosamente.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al aceptar la petición con ID {peticionId}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Delete
        [HttpDelete("{idPeticion}", Name = "DeletePeticion")]
        public ActionResult DeletePeticion([FromRoute] int idPeticion, int idUsuario)
        {
            try
            {
                _logger.LogInformation($"Solicitud para eliminar la petición con ID: {idPeticion}");
                // Verificar si el usuario tiene acceso al recurso
                var currentUser = HttpContext.User;
                if (!_authService.HasAccessToResource(currentUser, idUsuario))
                {
                    _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {idUsuario}.");
                    return Forbid();
                }

                _peticionService.DeletePeticion(idPeticion);
                _logger.LogInformation($"Petición con ID: {idPeticion} eliminada exitosamente.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la petición con ID {idPeticion}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
