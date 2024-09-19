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
        [HttpGet(Name = "GetAllEmpresas")]
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

        [HttpGet("{id}", Name = "GetIdEmpresa")]
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
        [HttpPost(Name = "CreateEmpresa")]
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

        [HttpPost("ciudad", Name = "AddCiudadEmpresa")]
        public ActionResult<EmpresaCiudad> AddCiudadEmpresa([FromBody] EmpresaCiudadDTO empresaCiudad)
        {
            try
            {
                if (empresaCiudad == null)
                {
                    return BadRequest();
                }
                _empresaService.AddCiudadEmpresa(empresaCiudad);
                return Ok(empresaCiudad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Put

        [HttpPut("{id}", Name = "UpdateEmpresa")]
        public IActionResult Update(int id, [FromBody] PutDatosEmpresaDTO empresa)
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
        [HttpDelete("{id}", Name = "DeleteEmpresa")]
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

        [HttpDelete("categoria", Name = "DeleteCategoriaEmpresa")]
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

        [HttpDelete("ciudad", Name = "DeleteCiudadEmpresa")]
        public IActionResult DeleteCiudadEmpresa([FromBody] EmpresaCiudadDTO empresaCiudad)
        {
            try
            {

                _empresaService.DeleteCiudadEmpresa(empresaCiudad);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
