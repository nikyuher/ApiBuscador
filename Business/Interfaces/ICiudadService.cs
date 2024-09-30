using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Business
{
    public interface ICiudadService
    {
        //Get
        public List<Ciudad> GetAll();
        public CiudadDTO GetCiudadId(int idCiudad);
        public List<CiudadDTO> BuscadorCiudadNombre(string nombre);
        public CiudadDTO GetCiudad(string nombre);
        public GetEmpresaCiudadDTO GetEmpresasCiudad(int id);
        public GetEmpresaCiudadDTO GetEmpresaCiudad(int idEmpresa, int idCiudad);

        //Create
        public Ciudad CreateCiudad(CiudadDTO ciudad);

        //Put
        public void UpdateCiudad(CiudadDTO ciudadDTO);

        //Delete
        public void DeleteCiudad(int idCiudad);
    }
}