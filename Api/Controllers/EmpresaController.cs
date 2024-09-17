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

        [HttpGet]
        public ActionResult<List<Empresa>> GetAll()
        {
            var empresas = _empresaService.GetAll();
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public ActionResult<Empresa> GetById(int id)
        {
            var empresa = _empresaService.GetById(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        [HttpPost]
        public ActionResult<Empresa> Create(AddEmpresaDTO empresa)
        {
            if (empresa == null)
            {
                return BadRequest();
            }
            _empresaService.Add(empresa);
            return Ok(empresa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Empresa empresa)
        {
            if (id != empresa.IdEmpresa)
            {
                return BadRequest();
            }

            var existingEmpresa = _empresaService.GetById(id);
            if (existingEmpresa == null)
            {
                return NotFound();
            }

            _empresaService.Update(empresa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var empresa = _empresaService.GetById(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _empresaService.Delete(id);
            return NoContent();
        }
    }
}
