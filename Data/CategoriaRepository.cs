using Microsoft.EntityFrameworkCore;
using Buscador.Models;

namespace Buscador.Data
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly BuscadorContext _context;

        public CategoriaRepository(BuscadorContext context)
        {
            _context = context;
        }

        //Get
        public List<Categoria> GetAll()
        {
            var empresas = _context.Categorias.ToList();

            return empresas;
        }

        public GetCategoriaDTO GetCategoria(string nombre)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Nombre == nombre);

            if (categoria == null)
            {
                throw new Exception($"No se encontró la categoría con el nombre: {nombre}");
            }

            var categoriaDTO = new GetCategoriaDTO
            {
                Nombre = categoria.Nombre
            };

            return categoriaDTO;
        }
        //Create 

        public Categoria CreateCategoria(AddCategoriaDTO categoria)
        {

            var newCategoria = new Categoria
            {
                Nombre = categoria.Nombre,
            };

            _context.Categorias.Add(newCategoria);
            SaveChanges();

            return newCategoria;
        }
        //Update
        public void UpdateCategoria(UpdateCategoriaDTO categoriaDTO)
        {
            var existingCategoria = _context.Categorias.Find(categoriaDTO.IdCategoria);
            if (existingCategoria == null)
            {
                throw new KeyNotFoundException("No se encontró la categoria a actualizar.");
            }

            existingCategoria.Nombre = categoriaDTO.Nombre;

            _context.Entry(existingCategoria).CurrentValues.SetValues(categoriaDTO);
            SaveChanges();
        }

        //Delete
        public void DeleteCategoria(int idCategoria)
        {

            var categoria = _context.Categorias.FirstOrDefault(c => c.IdCategoria == idCategoria);

            if (categoria is null)
            {
                throw new Exception($"No se encontro una categoria con el ID: {idCategoria}");
            }

            _context.Categorias.Remove(categoria);
            SaveChanges();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
