using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Business
{
    public interface IEmpresaService
    {
        //Get
        List<GetAllEmpresaDTO> GetAll();
        public List<EmpresaBusquedaDTO> BuscadorEmpresaNombre(string nombre);
        //Post
        Empresa GetById(int id);
        public EmpresaCategoria AddCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria);
        public EmpresaCiudad AddCiudadEmpresa(EmpresaCiudadDTO empresaCiudad);
        public Empresa Add(AddEmpresaDTO empresa);
        //Put
        void Update(PutDatosEmpresaDTO empresa);
        //Delete
        void Delete(int id);
        public void DeleteCategoriaEmpresa(int IdempresaCategoria);
        public void DeleteCiudadEmpresa(int IdempresaCiudad);
    }
}
