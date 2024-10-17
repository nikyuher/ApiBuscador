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
        public List<GetAllEmpresaDTO> GetAll() => _empresaRepository.GetAll();
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
        public void Update(PutDatosEmpresaDTO empresa) => _empresaRepository.Update(empresa);


        //Delete
        public void Delete(int id) => _empresaRepository.Delete(id);
        public void DeleteCategoriaEmpresa(int IdempresaCategoria)
        {
            _empresaRepository.DeleteCategoriaEmpresa(IdempresaCategoria);
        }
        public void DeleteCiudadEmpresa(int IdempresaCiudad)
        {
            _empresaRepository.DeleteCiudadEmpresa(IdempresaCiudad);
        }
    }
}
