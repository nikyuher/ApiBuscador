using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using Buscador.Data;

using System.Collections.Generic;

namespace Buscador.Business
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriRepository)
        {
            _categoriaRepository = categoriRepository;
        }

        public List<Categoria> GetAll() => _categoriaRepository.GetAll();

        public GetCategoriaDTO GetCategoriaId(int idCategoria)
        {
            return _categoriaRepository.GetCategoriaId(idCategoria);
        }

        public GetCategoriaEmpresasDTO GetEmpresaSCategoria(int id)
        {
            return _categoriaRepository.GetEmpresaSCategoria(id);
        }
        public async Task<int> GetEmpresaNumCategoriaAsync(int id)
        {
            return await _categoriaRepository.GetEmpresaNumCategoriaAsync(id);
        }
        public GetCategoriaDTO GetCategoria(string nombre)
        {
            var categoria = _categoriaRepository.GetCategoria(nombre);
            return categoria;
        }
        public Categoria CreateCategoria(AddCategoriaDTO categoria)
        {
            var newCategoria = _categoriaRepository.CreateCategoria(categoria);
            return newCategoria;
        }
        public void UpdateCategoria(UpdateCategoriaDTO categoriaDTO)
        {
            _categoriaRepository.UpdateCategoria(categoriaDTO);

        }
        public void DeleteCategoria(int idCategoria)
        {
            _categoriaRepository.DeleteCategoria(idCategoria);
        }

    }
}