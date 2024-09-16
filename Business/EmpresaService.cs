using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using Buscador.Data;

using System.Collections.Generic;

namespace Buscador.Business
{
    public class EmpresaService :IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public List<Empresa> GetAll() => _empresaRepository.GetAll();

    }
}
