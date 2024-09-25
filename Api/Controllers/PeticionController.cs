using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Buscador.Models;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PeticionController : ControllerBase
    {
        private readonly IPeticionService _peticionService;

        public PeticionController(IPeticionService peticionService)
        {
            _peticionService = peticionService;
        }

        // Get
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<PeticionDTO>> GetAll()
        {
            var peticiones = _peticionService.GetAll();
            return Ok(peticiones);
        }

        //Post
        [HttpPost(Name = "AddPeticion")]

        public ActionResult AddPeticion([FromBody] AddPeticionDTO peticionDTO)
        {

            try
            {

                var peticion = _peticionService.AddPeticion(peticionDTO);
                return Ok(peticion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("validar", Name = "AceptarPeticion")]

        public ActionResult AceptarPeticion([FromBody] int peticionId)
        {

            try
            {

                _peticionService.AceptarPeticion(peticionId);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Delete
        [HttpDelete("{idPeticion}", Name = "DeletePeticion")]

        public ActionResult DeletePeticion([FromRoute] int idPeticion)
        {

            try
            {

                _peticionService.DeletePeticion(idPeticion);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
