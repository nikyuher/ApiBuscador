using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface IEmpresaService
    {
        List<Empresa> GetAll();
        public List<Empresa> GetEmpresaNombre(string nombre);
        Empresa GetById(int id);
        Empresa Add(AddEmpresaDTO empresa);
        void Update(Empresa empresa);
        void Delete(int id);
    }
}
