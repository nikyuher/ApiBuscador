using Microsoft.AspNetCore.Mvc;
using Buscador.Models;
using Buscador.Data;
using Buscador.Business;
using System.Collections.Generic;

namespace Buscador.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{
    public class EmpresasController : ControllerBase
    {
        private readonly EmpresaService _empresaService;

        public EmpresasController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }


        [HttpGet()]
        public ActionResult<List<Empresa>> GetAll() => _empresaService.GetAll();
}
}