using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Business
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public List<Empresa> GetAll() => _empresaRepository.GetAll();

        public Empresa GetById(int id) => _empresaRepository.GetById(id);

        public Empresa Add(AddEmpresaDTO empresa) => _empresaRepository.Add(empresa);

        public void Update(Empresa empresa) => _empresaRepository.Update(empresa);

        public void Delete(int id) => _empresaRepository.Delete(id);
    }
}
