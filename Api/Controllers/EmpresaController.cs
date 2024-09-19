using Microsoft.AspNetCore.Mvc;
using Buscador.Models;
using Buscador.Data;
using Buscador.Business;
using System.Collections.Generic;

namespace Buscador.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }


        //Get
        [HttpGet]
        public ActionResult<List<Empresa>> GetAll()
        {
            try
            {
                var empresas = _empresaService.GetAll();
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("buscar", Name = "BuscadorEmpresaNombre")]
        public ActionResult<List<Empresa>> BuscadorEmpresaNombre([FromBody] string nombre)
        {

            try
            {

                var empresas = _empresaService.BuscadorEmpresaNombre(nombre);
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Empresa> GetById([FromBody] int id)
        {

            try
            {
                var empresa = _empresaService.GetById(id);
                if (empresa == null)
                {
                    return BadRequest();
                }
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        //Create
        [HttpPost]
        public ActionResult<Empresa> Create([FromBody] AddEmpresaDTO empresa)
        {
            try
            {
                if (empresa == null)
                {
                    return BadRequest();
                }
                _empresaService.Add(empresa);
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("categoria", Name = "AddCategoriaEmpresa")]
        public ActionResult<EmpresaCategoria> AddCategoriaEmpresa([FromBody] AddEmpresaCategoriaDTO empresaCategoria)
        {
            try
            {
                if (empresaCategoria == null)
                {
                    return BadRequest();
                }
                _empresaService.AddCategoriaEmpresa(empresaCategoria);
                return Ok(empresaCategoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Put

        [HttpPut("{id}")]
        public IActionResult Update( int id, [FromBody] Empresa empresa)
        {

            try
            {
                if (id != empresa.IdEmpresa)
                {
                    return BadRequest();
                }

                var existingEmpresa = _empresaService.GetById(id);
                if (existingEmpresa == null)
                {
                    return BadRequest();
                }

                _empresaService.Update(empresa);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                var empresa = _empresaService.GetById(id);
                if (empresa == null)
                {
                    return BadRequest();
                }

                _empresaService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("categoria")]
        public IActionResult DeleteCategoriaEmpresa([FromBody] AddEmpresaCategoriaDTO empresaCategoria)
        {
            try
            {

                _empresaService.DeleteCategoriaEmpresa(empresaCategoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
