using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using Buscador.Data;

using System.Collections.Generic;

namespace Buscador.Business
{
    public class CiudadService : ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;

        public CiudadService(ICiudadRepository ciudadRepository)
        {
            _ciudadRepository = ciudadRepository;
        }


        //GET
        public List<Ciudad> GetAll()
        {
            return _ciudadRepository.GetAll();
        }
        public CiudadDTO GetCiudadId(int idCiudad)
        {
            return _ciudadRepository.GetCiudadId(idCiudad);
        }
        public List<CiudadDTO> BuscadorCiudadNombre(string nombre)
        {
            return _ciudadRepository.BuscadorCiudadNombre(nombre);
        }
        public CiudadDTO GetCiudad(string nombre)
        {
            return _ciudadRepository.GetCiudad(nombre);
        }
        public GetEmpresaCiudadDTO GetEmpresasCiudad(int id)
        {
            return _ciudadRepository.GetEmpresasCiudad(id);
        }
        public GetEmpresaCiudadDTO GetEmpresaCiudad(int idEmpresa, int idCiudad)
        {
            return _ciudadRepository.GetEmpresaCiudad(idEmpresa, idCiudad);
        }

        //Create
        public Ciudad CreateCiudad(CiudadDTO ciudad)
        {
            return _ciudadRepository.CreateCiudad(ciudad);
        }

        //Put
        public void UpdateCiudad(CiudadDTO ciudadDTO)
        {
            _ciudadRepository.UpdateCiudad(ciudadDTO);
        }

        //Delete
        public void DeleteCiudad(int idCiudad)
        {
            _ciudadRepository.DeleteCiudad(idCiudad);
        }

    }
}
