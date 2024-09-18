using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Data
{
    public interface ICiudadRepository
    {
        public List<Ciudad> GetAll();
        public CiudadDTO GetCiudad(string nombre);
        public Ciudad CreateCiudad(CiudadDTO ciudad);
        public void UpdateCiudad(CiudadDTO ciudadDTO);
        public void DeleteCiudad(int idCiudad);
    }
}