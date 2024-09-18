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


        public List<Ciudad> GetAll()
        {
            return _ciudadRepository.GetAll();
        }
        public CiudadDTO GetCiudadId(int idCiudad)
        {
            return _ciudadRepository.GetCiudadId(idCiudad);
        }
        public CiudadDTO GetCiudad(string nombre)
        {
            return _ciudadRepository.GetCiudad(nombre);
        }
        public Ciudad CreateCiudad(CiudadDTO ciudad)
        {
            return _ciudadRepository.CreateCiudad(ciudad);
        }
        public void UpdateCiudad(CiudadDTO ciudadDTO)
        {
            _ciudadRepository.UpdateCiudad(ciudadDTO);
        }
        public void DeleteCiudad(int idCiudad)
        {
            _ciudadRepository.DeleteCiudad(idCiudad);
        }

    }
}
