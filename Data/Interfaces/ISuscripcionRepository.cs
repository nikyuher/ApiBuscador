using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface ISuscripcionRepository
    {
        Task<List<SuscripcionDTO>> GetAll();
        Task<UsuarioTipoSuscripcionDTO> GetUsuariosSuscritosPlan(int IdSuscripcion);
        Task<Suscripcion> Create(SuscripcionDatosDTO datos);
        Task AñadirSuscripcionUser(AddUsuarioSuscripcionDTO datos);
        Task<Suscripcion> UpdateDatos(SuscripcionDatosDTO datos);
        Task<Suscripcion> Delete(int IdSuscripcion);
        Task VerificarSuscripciones();
    }
}
