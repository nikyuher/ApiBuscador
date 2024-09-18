using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface IEmpresaRepository
    {
        List<Empresa> GetAll();
        public List<Empresa> GetEmpresaNombre(string nombre);
        Empresa GetById(int id);
        public Empresa Add(AddEmpresaDTO empresa);
        void Update(Empresa empresa);
        void Delete(int id);
    }
}
