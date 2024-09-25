using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Buscador.Models;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService _ciudadService;

        public CiudadController(ICiudadService ciudadService)
        {
            _ciudadService = ciudadService;
        }

        // Get
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Ciudad>> GetAll()
        {
            var ciudades = _ciudadService.GetAll();
            return Ok(ciudades);
        }

        [AllowAnonymous]
        [HttpGet("{idCiudad}", Name = "GetCiudadId")]

        public ActionResult<CiudadDTO> GetCiudadId([FromRoute] int idCiudad)
        {
            try
            {

                var ciudad = _ciudadService.GetCiudadId(idCiudad);

                return Ok(ciudad);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("buscar", Name = "GetCiudadNombre")]
        public ActionResult<List<CiudadDTO>> GetCiudadNombre([FromQuery] string nombre)
        {

            try
            {

                var ciudad = _ciudadService.BuscadorCiudadNombre(nombre);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("nombre", Name = "GetCiudad")]

        public ActionResult<CiudadDTO> GetCiudad([FromQuery] string nombre)
        {
            try
            {

                var ciudad = _ciudadService.GetCiudad(nombre);

                return Ok(ciudad);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCiudad}/empresas", Name = "GetEmpresasCiudad")]
        public ActionResult<GetEmpresaCiudadDTO> GetEmpresasCiudad([FromRoute] int idCiudad)
        {
            try
            {

                var ciudad = _ciudadService.GetEmpresasCiudad(idCiudad);

                return Ok(ciudad);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [AllowAnonymous]
        [HttpGet("empresa", Name = "GetEmpresaCiudad")]
        public ActionResult<GetEmpresaCiudadDTO> GetEmpresaCiudad([FromQuery] int idEmpresa, [FromQuery] int idCiudad)
        {
            try
            {
                var ciudad = _ciudadService.GetEmpresaCiudad(idEmpresa, idCiudad);

                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        //Post
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "AddCiudad")]

        public ActionResult AddCiudad([FromBody] CiudadDTO ciudadDTO)
        {

            try
            {

                var ciudad = _ciudadService.CreateCiudad(ciudadDTO);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Update

        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "UpdateCiudad")]

        public ActionResult UpdateCiudad([FromBody] CiudadDTO ciudadDTO)
        {

            try
            {

                _ciudadService.UpdateCiudad(ciudadDTO);
                return Ok(ciudadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete("{idCiudad}", Name = "DeleteCiudad")]

        public ActionResult DeleteCiudad([FromRoute] int idCiudad)
        {

            try
            {

                _ciudadService.DeleteCiudad(idCiudad);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
