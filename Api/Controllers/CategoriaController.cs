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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaService categoriaService, ILogger<CategoriaController> logger)
        {
            _categoriaService = categoriaService;
            _logger = logger;
        }

        // Get
        [AllowAnonymous]
        [HttpGet(Name = "GetAll")]
        public ActionResult<List<Categoria>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitud para obtener todas las categorías.");
                var categorias = _categoriaService.GetAll();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todas las categorías: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCategoria}", Name = "GetCategoriaId")]
        public ActionResult<GetCategoriaDTO> GetCategoriaId([FromRoute] int idCategoria)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener la categoría con ID: {idCategoria}");
                var categoria = _categoriaService.GetCategoriaId(idCategoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la categoría con ID {idCategoria}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCategoria}/empresas", Name = "GetEmpresasCategoria")]
        public ActionResult<GetCategoriaEmpresasDTO> GetEmpresasCategoria([FromRoute] int idCategoria)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener empresas de la categoría con ID: {idCategoria}");
                var categoria = _categoriaService.GetEmpresaSCategoria(idCategoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener empresas de la categoría con ID {idCategoria}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("nombre", Name = "GetCategoria")]
        public ActionResult<GetCategoriaDTO> GetCategoria([FromQuery] string nombre)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener la categoría con nombre: {nombre}");
                var categoria = _categoriaService.GetCategoria(nombre);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la categoría con nombre {nombre}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Post
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "AddCategoria")]
        public ActionResult AddCategoria([FromBody] AddCategoriaDTO categoriaDTO)
        {
            try
            {
                _logger.LogInformation("Solicitud para agregar una nueva categoría.");
                var categoria = _categoriaService.CreateCategoria(categoriaDTO);
                _logger.LogInformation($"Categoría creada exitosamente: {categoriaDTO.Nombre}");
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al agregar la categoría: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Update
        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "UpdateCategoria")]
        public ActionResult UpdateCategoria([FromBody] UpdateCategoriaDTO categoriaDTO)
        {
            try
            {
                _logger.LogInformation($"Solicitud para actualizar la categoría con ID: {categoriaDTO.IdCategoria}");
                _categoriaService.UpdateCategoria(categoriaDTO);
                _logger.LogInformation($"Categoría con ID {categoriaDTO.IdCategoria} actualizada exitosamente.");
                return Ok(categoriaDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la categoría con ID {categoriaDTO.IdCategoria}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete("{idCategoria}", Name = "DeleteCategoria")]
        public ActionResult DeleteCategoria([FromRoute] int idCategoria)
        {
            try
            {
                _logger.LogInformation($"Solicitud para eliminar la categoría con ID: {idCategoria}");
                _categoriaService.DeleteCategoria(idCategoria);
                _logger.LogInformation($"Categoría con ID {idCategoria} eliminada exitosamente.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la categoría con ID {idCategoria}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
