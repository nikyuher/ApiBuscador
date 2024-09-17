using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Data{
    public interface ICategoriaRepository{
       public List<Categoria> GetAll();
    }
}