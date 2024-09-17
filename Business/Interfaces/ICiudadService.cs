using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Data{
    public interface ICiudadService{
       public List<Ciudad> GetAll();
    }
}