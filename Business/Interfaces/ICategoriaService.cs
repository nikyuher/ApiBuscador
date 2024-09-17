using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Data{
    public interface ICategoriaService{
       public List<Categoria> GetAll();
        public GetCategoriaDTO GetCategoria(string nombre);
        public Categoria CreateCategoria(AddCategoriaDTO categoria);
        public void UpdateCategoria(UpdateCategoriaDTO categoriaDTO);
        public void DeleteCategoria(int idCategoria);
    }
}