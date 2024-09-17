using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Data{
    public interface ICiudadRepository{
       public List<Ciudad> GetAll();
    }
}