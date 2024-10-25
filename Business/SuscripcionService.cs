using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Business
{
    public class SuscripcionService : ISuscripcionService
    {
        private readonly ISuscripcionRepository _suscripcionRepository;

        public SuscripcionService(ISuscripcionRepository suscripcionRepository)
        {
            _suscripcionRepository = suscripcionRepository;
        }

        public async Task<List<SuscripcionDTO>> GetAll()
        {
            return await _suscripcionRepository.GetAll();
        }

        public async Task<UsuarioTipoSuscripcionDTO> GetUsuariosSuscritosPlan(int IdSuscripcion)
        {
            return await _suscripcionRepository.GetUsuariosSuscritosPlan(IdSuscripcion);
        }

        public async Task<Suscripcion> Create(SuscripcionDatosDTO datos)
        {
            return await _suscripcionRepository.Create(datos);
        }
        public async Task AñadirSuscripcionUser(AddUsuarioSuscripcionDTO datos)
        {
            await _suscripcionRepository.AñadirSuscripcionUser(datos);
        }
        public async Task<Suscripcion> UpdateDatos(SuscripcionDatosDTO datos)
        {
            return await _suscripcionRepository.UpdateDatos(datos);
        }
        public async Task<Suscripcion> Delete(int IdSuscripcion)
        {
            return await _suscripcionRepository.Delete(IdSuscripcion);
        }

        public async Task VerificarSuscripciones()
        {
            await _suscripcionRepository.VerificarSuscripciones();
        }
    }
}
