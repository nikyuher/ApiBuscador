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


        //Get
        public List<Empresa> GetAll() => _empresaRepository.GetAll();
        public List<Empresa> BuscadorEmpresaNombre(string nombre)
        {
            return _empresaRepository.BuscadorEmpresaNombre(nombre);
        }

        public Empresa GetById(int id) => _empresaRepository.GetById(id);


        //Create
        public Empresa Add(AddEmpresaDTO empresa) => _empresaRepository.Add(empresa);
        public EmpresaCategoria AddCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria)
        {
            return _empresaRepository.AddCategoriaEmpresa(empresaCategoria);
        }

        public EmpresaCiudad AddCiudadEmpresa(EmpresaCiudadDTO empresaCiudad)
        {
            return _empresaRepository.AddCiudadEmpresa(empresaCiudad);
        }

        //Update
        public void Update(Empresa empresa) => _empresaRepository.Update(empresa);


        //Delete
        public void Delete(int id) => _empresaRepository.Delete(id);
        public void DeleteCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria)
        {
            _empresaRepository.DeleteCategoriaEmpresa(empresaCategoria);
        }
        public void DeleteCiudadEmpresa(EmpresaCiudadDTO empresaCiudad)
        {
            _empresaRepository.DeleteCiudadEmpresa(empresaCiudad);
        }
    }
}
