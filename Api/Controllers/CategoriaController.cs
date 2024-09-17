using Microsoft.AspNetCore.Mvc;
using Buscador.Models;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // Devuelve la lista de todas las empresas
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

        [HttpGet("{nombre}", Name = "GetCategoria")]

        public ActionResult<GetCategoriaDTO> GetCategoria(string nombre)
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

        [HttpPut(Name = "UpdateCategoria")]

        public ActionResult UpdateCategoria([FromBody] UpdateCategoriaDTO categoriaDTO)
        {

            try
            {

                _categoriaService.UpdateCategoria(categoriaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Delete
        [HttpDelete(Name = "DeleteCategoria")]

        public ActionResult DeleteCategoria([FromBody] int idCategoria)
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
