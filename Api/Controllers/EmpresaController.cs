using Microsoft.AspNetCore.Mvc;
using Buscador.Models;
using Buscador.Business;
using System.Collections.Generic;
using Buscador.Data;

namespace Buscador.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        // Inyecta el servicio usando la interfaz
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        // Devuelve la lista de todas las empresas
        [HttpGet]
        public ActionResult<List<Empresa>> GetAll()
        {
            var empresas = _empresaService.GetAll();
            return Ok(empresas); // Devuelve un 200 OK con la lista de empresas
        }
    }
}
