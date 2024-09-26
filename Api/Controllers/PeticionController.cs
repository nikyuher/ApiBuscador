using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Buscador.Models;
using Buscador.Data;
using Microsoft.Extensions.Logging;

namespace Buscador.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PeticionController : ControllerBase
    {
        private readonly IPeticionService _peticionService;
        private readonly ILogger<PeticionController> _logger;

        public PeticionController(IPeticionService peticionService, ILogger<PeticionController> logger)
        {
            _peticionService = peticionService;
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
        public ActionResult AceptarPeticion([FromBody] int peticionId)
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
        public ActionResult DeletePeticion([FromRoute] int idPeticion)
        {
            try
            {
                _logger.LogInformation($"Solicitud para eliminar la petición con ID: {idPeticion}");
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
