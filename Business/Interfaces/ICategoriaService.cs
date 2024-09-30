using Microsoft.EntityFrameworkCore;
using Buscador.Models;


namespace Buscador.Business
{
    public interface ICategoriaService
    {
        public List<Categoria> GetAll();
        public GetCategoriaDTO GetCategoria(string nombre);
        public GetCategoriaEmpresasDTO GetEmpresaSCategoria(int id);
        public GetCategoriaDTO GetCategoriaId(int categoriaId);
        public Categoria CreateCategoria(AddCategoriaDTO categoria);
        public void UpdateCategoria(UpdateCategoriaDTO categoriaDTO);
        public void DeleteCategoria(int idCategoria);
    }
}