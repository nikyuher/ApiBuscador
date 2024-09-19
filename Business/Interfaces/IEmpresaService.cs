using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface IEmpresaService
    {
        //Get
        List<Empresa> GetAll();
        public List<Empresa> BuscadorEmpresaNombre(string nombre);
        //Post
        Empresa GetById(int id);
        public EmpresaCategoria AddCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria);
        public EmpresaCiudad AddCiudadEmpresa(EmpresaCiudadDTO empresaCiudad);
        public Empresa Add(AddEmpresaDTO empresa);
        //Put
        void Update(Empresa empresa);
        //Delete
        void Delete(int id);
        public void DeleteCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria);
        public void DeleteCiudadEmpresa(EmpresaCiudadDTO empresaCiudad);
    }
}
