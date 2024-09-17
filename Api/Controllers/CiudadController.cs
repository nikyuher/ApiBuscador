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

        // Devuelve la lista de todas las empresas
        [HttpGet]
        public ActionResult<List<Ciudad>> GetAll()
        {
            var ciudades = _ciudadService.GetAll();
            return Ok(ciudades); 
        }
    }
}
