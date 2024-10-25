using Buscador.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Buscador.Business
{
    public interface ISuscripcionService
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