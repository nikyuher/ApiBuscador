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
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService _ciudadService;
        private readonly ILogger<CiudadController> _logger;

        public CiudadController(ICiudadService ciudadService, ILogger<CiudadController> logger)
        {
            _ciudadService = ciudadService;
            _logger = logger;
        }

        // Get
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Ciudad>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitud para obtener todas las ciudades.");
                var ciudades = _ciudadService.GetAll();
                return Ok(ciudades);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todas las ciudades: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCiudad}", Name = "GetCiudadId")]
        public ActionResult<CiudadDTO> GetCiudadId([FromRoute] int idCiudad)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener la ciudad con ID: {idCiudad}");
                var ciudad = _ciudadService.GetCiudadId(idCiudad);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la ciudad con ID {idCiudad}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("buscar", Name = "GetCiudadNombre")]
        public ActionResult<List<CiudadDTO>> GetCiudadNombre([FromQuery] string nombre)
        {
            try
            {
                _logger.LogInformation($"Solicitud para buscar ciudad con nombre: {nombre}");
                var ciudad = _ciudadService.BuscadorCiudadNombre(nombre);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al buscar la ciudad con nombre {nombre}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("nombre", Name = "GetCiudad")]
        public ActionResult<CiudadDTO> GetCiudad([FromQuery] string nombre)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener ciudad con nombre: {nombre}");
                var ciudad = _ciudadService.GetCiudad(nombre);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la ciudad con nombre {nombre}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCiudad}/empresas", Name = "GetEmpresasCiudad")]
        public ActionResult<GetEmpresaCiudadDTO> GetEmpresasCiudad([FromRoute] int idCiudad)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener empresas en la ciudad con ID: {idCiudad}");
                var ciudad = _ciudadService.GetEmpresasCiudad(idCiudad);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener empresas de la ciudad con ID {idCiudad}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("empresa", Name = "GetEmpresaCiudad")]
        public ActionResult<GetEmpresaCiudadDTO> GetEmpresaCiudad([FromQuery] int idEmpresa, [FromQuery] int idCiudad)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener la empresa con ID {idEmpresa} en la ciudad con ID {idCiudad}");
                var ciudad = _ciudadService.GetEmpresaCiudad(idEmpresa, idCiudad);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la empresa con ID {idEmpresa} en la ciudad con ID {idCiudad}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Post
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "AddCiudad")]
        public ActionResult AddCiudad([FromBody] CiudadDTO ciudadDTO)
        {
            try
            {
                _logger.LogInformation("Solicitud para agregar una nueva ciudad.");
                var ciudad = _ciudadService.CreateCiudad(ciudadDTO);
                _logger.LogInformation($"Ciudad creada exitosamente: {ciudadDTO.Nombre}");
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al agregar la ciudad: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Update
        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "UpdateCiudad")]
        public ActionResult UpdateCiudad([FromBody] CiudadDTO ciudadDTO)
        {
            try
            {
                _logger.LogInformation($"Solicitud para actualizar la ciudad con ID: {ciudadDTO.IdCiudad}");
                _ciudadService.UpdateCiudad(ciudadDTO);
                _logger.LogInformation($"Ciudad con ID {ciudadDTO.IdCiudad} actualizada exitosamente.");
                return Ok(ciudadDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la ciudad con ID {ciudadDTO.IdCiudad}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete("{idCiudad}", Name = "DeleteCiudad")]
        public ActionResult DeleteCiudad([FromRoute] int idCiudad)
        {
            try
            {
                _logger.LogInformation($"Solicitud para eliminar la ciudad con ID: {idCiudad}");
                _ciudadService.DeleteCiudad(idCiudad);
                _logger.LogInformation($"Ciudad con ID {idCiudad} eliminada exitosamente.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la ciudad con ID {idCiudad}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
