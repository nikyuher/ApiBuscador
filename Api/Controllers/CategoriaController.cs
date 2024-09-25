using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Buscador.Models;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // Get
        [AllowAnonymous]
        [HttpGet(Name = "GetAll")]
        public ActionResult<List<Categoria>> GetAll()
        {

            try
            {

                var categorias = _categoriaService.GetAll();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCategoria}", Name = "GetCategoriaId")]

        public ActionResult<GetCategoriaDTO> GetCategoriaId([FromRoute] int idCategoria)
        {
            try
            {

                var categoria = _categoriaService.GetCategoriaId(idCategoria);

                return Ok(categoria);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCategoria}/empresas", Name = "GetEmpresasCategoria")]
        public ActionResult<GetCategoriaEmpresasDTO> GetEmpresasCategoria([FromRoute] int idCategoria)
        {
            try
            {

                var categoria = _categoriaService.GetEmpresaSCategoria(idCategoria);

                return Ok(categoria);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("nombre", Name = "GetCategoria")]

        public ActionResult<GetCategoriaDTO> GetCategoria([FromQuery] string nombre)
        {


            try
            {

                var categoria = _categoriaService.GetCategoria(nombre);

                return Ok(categoria);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Post
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "AddCategoria")]

        public ActionResult AddCategoria([FromBody] AddCategoriaDTO categoriaDTO)
        {

            try
            {

                var categoria = _categoriaService.CreateCategoria(categoriaDTO);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Update
        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "UpdateCategoria")]

        public ActionResult UpdateCategoria([FromBody] UpdateCategoriaDTO categoriaDTO)
        {

            try
            {

                _categoriaService.UpdateCategoria(categoriaDTO);
                return Ok(categoriaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete("{idCategoria}", Name = "DeleteCategoria")]

        public ActionResult DeleteCategoria([FromRoute] int idCategoria)
        {

            try
            {

                _categoriaService.DeleteCategoria(idCategoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
