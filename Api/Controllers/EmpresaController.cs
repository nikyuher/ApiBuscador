using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Buscador.Models;
using Buscador.Business;
using Microsoft.Extensions.Logging;

namespace Buscador.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(IEmpresaService empresaService, ILogger<EmpresaController> logger)
        {
            _empresaService = empresaService;
            _logger = logger;
        }

        //Get
        [AllowAnonymous]
        [HttpGet(Name = "GetAllEmpresas")]
        public ActionResult<List<Empresa>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitud para obtener todas las empresas.");
                var empresas = _empresaService.GetAll();
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todas las empresas: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("buscar", Name = "BuscadorEmpresaNombre")]
        public ActionResult<List<Empresa>> BuscadorEmpresaNombre([FromQuery] string nombre)
        {
            try
            {
                _logger.LogInformation($"Solicitud para buscar empresas por nombre: {nombre}");
                var empresas = _empresaService.BuscadorEmpresaNombre(nombre);
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al buscar empresas por nombre {nombre}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetIdEmpresa")]
        public ActionResult<Empresa> GetById([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation($"Solicitud para obtener la empresa con ID: {id}");
                var empresa = _empresaService.GetById(id);
                if (empresa == null)
                {
                    _logger.LogWarning($"No se encontró la empresa con ID: {id}");
                    return BadRequest();
                }
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la empresa con ID {id}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Create
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreateEmpresa")]
        public ActionResult<Empresa> Create([FromBody] AddEmpresaDTO empresa)
        {
            try
            {
                if (empresa == null)
                {
                    _logger.LogWarning("Solicitud para crear una empresa fallida debido a datos inválidos.");
                    return BadRequest();
                }
                _empresaService.Add(empresa);
                _logger.LogInformation($"Empresa creada exitosamente: {empresa.Nombre}");
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear la empresa: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("categoria", Name = "AddCategoriaEmpresa")]
        public ActionResult<EmpresaCategoria> AddCategoriaEmpresa([FromBody] AddEmpresaCategoriaDTO empresaCategoria)
        {
            try
            {
                if (empresaCategoria == null)
                {
                    _logger.LogWarning("Solicitud para agregar una categoría fallida debido a datos inválidos.");
                    return BadRequest();
                }
                _empresaService.AddCategoriaEmpresa(empresaCategoria);
                _logger.LogInformation($"Categoría agregada exitosamente a la empresa con ID: {empresaCategoria.IdEmpresa}");
                return Ok(empresaCategoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al agregar la categoría a la empresa: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("ciudad", Name = "AddCiudadEmpresa")]
        public ActionResult<EmpresaCiudad> AddCiudadEmpresa([FromBody] EmpresaCiudadDTO empresaCiudad)
        {
            try
            {
                if (empresaCiudad == null)
                {
                    _logger.LogWarning("Solicitud para agregar una ciudad fallida debido a datos inválidos.");
                    return BadRequest();
                }
                _empresaService.AddCiudadEmpresa(empresaCiudad);
                _logger.LogInformation($"Ciudad agregada exitosamente a la empresa con ID: {empresaCiudad.IdEmpresa}");
                return Ok(empresaCiudad);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al agregar la ciudad a la empresa: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Put
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}", Name = "UpdateEmpresa")]
        public IActionResult Update([FromRoute] int id, [FromBody] PutDatosEmpresaDTO empresa)
        {
            try
            {
                if (id != empresa.IdEmpresa)
                {
                    _logger.LogWarning($"El ID de la empresa en la solicitud no coincide. ID proporcionado: {id}, ID en el cuerpo: {empresa.IdEmpresa}");
                    return BadRequest();
                }

                var existingEmpresa = _empresaService.GetById(id);
                if (existingEmpresa == null)
                {
                    _logger.LogWarning($"No se encontró la empresa con ID: {id}");
                    return BadRequest();
                }

                _empresaService.Update(empresa);
                _logger.LogInformation($"Empresa con ID: {id} actualizada exitosamente.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la empresa con ID {id}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeleteEmpresa")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var empresa = _empresaService.GetById(id);
                if (empresa == null)
                {
                    _logger.LogWarning($"No se encontró la empresa con ID: {id} para eliminar.");
                    return BadRequest();
                }

                _empresaService.Delete(id);
                _logger.LogInformation($"Empresa con ID: {id} eliminada exitosamente.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la empresa con ID {id}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("categoria", Name = "DeleteCategoriaEmpresa")]
        public IActionResult DeleteCategoriaEmpresa(int IdEmpresaCategoria)
        {
            try
            {
                _logger.LogInformation($"Solicitud para eliminar la categoría de la empresa con ID: {IdEmpresaCategoria}");
                _empresaService.DeleteCategoriaEmpresa(IdEmpresaCategoria);
                _logger.LogInformation($"Categoría eliminada exitosamente de la empresa con ID: {IdEmpresaCategoria}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la categoría de la empresa con ID {IdEmpresaCategoria}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("ciudad", Name = "DeleteCiudadEmpresa")]
        public IActionResult DeleteCiudadEmpresa(int IdEmpresaCiudad)
        {
            try
            {
                _logger.LogInformation($"Solicitud para eliminar la ciudad de la empresa con ID: {IdEmpresaCiudad}");
                _empresaService.DeleteCiudadEmpresa(IdEmpresaCiudad);
                _logger.LogInformation($"Ciudad eliminada exitosamente de la empresa con ID: {IdEmpresaCiudad}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la ciudad de la empresa con ID {IdEmpresaCiudad}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
