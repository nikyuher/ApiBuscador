using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using Buscador.Data;

using System.Collections.Generic;

namespace Buscador.Business
{
    public class CiudadService :ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;

        public CiudadService(ICiudadRepository ciudadRepository)
        {
            _ciudadRepository = ciudadRepository;
        }

        public List<Ciudad> GetAll() => _ciudadRepository.GetAll();

    }
}
