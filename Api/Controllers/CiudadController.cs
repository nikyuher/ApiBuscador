using Microsoft.AspNetCore.Mvc;
using Buscador.Models;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
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
        [HttpGet]
        public ActionResult<List<Ciudad>> GetAll()
        {
            var ciudades = _ciudadService.GetAll();
            return Ok(ciudades);
        }

        [HttpGet("id/{idCiudad}", Name = "GetCiudadId")]

        public ActionResult<CiudadDTO> GetCiudadId([FromQuery] int idCiudad)
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

        [HttpGet("{nombre}", Name = "GetCiudad")]

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

        //Post
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
        [HttpDelete(Name = "DeleteCiudad")]

        public ActionResult DeleteCiudad([FromBody] int idCiudad)
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
