using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface IEmpresaRepository
    {
        //Get
        List<Empresa> GetAll();
        public List<Empresa> BuscadorEmpresaNombre(string nombre);
        //Post
        Empresa GetById(int id);
        public EmpresaCategoria AddCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria);
        public Empresa Add(AddEmpresaDTO empresa);
        //Put
        void Update(Empresa empresa);
        //Delete
        void Delete(int id);
    }
}
