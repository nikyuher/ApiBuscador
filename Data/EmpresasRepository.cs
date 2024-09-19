﻿using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using System.Text;
using System.Globalization;

namespace Buscador.Data
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly BuscadorContext _context;

        public EmpresaRepository(BuscadorContext context)
        {
            _context = context;
        }

        //Get
        public List<Empresa> GetAll()
        {
            return _context.Empresas.ToList();
        }

        public List<Empresa> BuscadorEmpresaNombre(string nombre)
        {
            var normalizedNombre = RemoveDiacritics(nombre.ToLower());

            var empresas = _context.Empresas
                .AsEnumerable()
                .Where(e => RemoveDiacritics(e.Nombre.ToLower()).Contains(normalizedNombre))
                .OrderBy(e => RemoveDiacritics(e.Nombre.ToLower()).IndexOf(normalizedNombre))
                .ToList();

            if (!empresas.Any())
            {
                throw new Exception($"No existe una empresa con un nombre relacionado a {nombre}");
            }

            return empresas;
        }

        public Empresa GetById(int id)
        {
            return _context.Empresas.Find(id);
        }

        //Post
        public Empresa Add(AddEmpresaDTO empresa)
        {
            var newEmpresa = new Empresa
            {
                Nombre = empresa.Nombre,
                Descripcion = empresa.Descripcion,
                Direccion = empresa.Direccion,
                Imagen = empresa.Imagen
            };
            _context.Empresas.Add(newEmpresa);

            _context.SaveChanges();

            return newEmpresa;
        }

        public EmpresaCategoria AddCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria)
        {
            var existingCategoriaEmpresa = _context.EmpresaCategorias
                .FirstOrDefault(ec => ec.IdCategoria == empresaCategoria.IdCategoria && ec.IdEmpresa == empresaCategoria.IdEmpresa);

            if (existingCategoriaEmpresa != null)
            {
                throw new Exception("La empresa ya está asociada a esta categoría.");
            }

            var newCategoriaEmpresa = new EmpresaCategoria
            {
                IdCategoria = empresaCategoria.IdCategoria,
                IdEmpresa = empresaCategoria.IdEmpresa
            };

            _context.EmpresaCategorias.Add(newCategoriaEmpresa);
            _context.SaveChanges();

            return newCategoriaEmpresa;
        }

        //Update
        public void Update(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;
            _context.SaveChanges();
        }


        //Delete
        public void Delete(int id)
        {

            var empresa = _context.Empresas.Find(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("La empresa solicitada no existe.");
            }
        }

        public void DeleteCategoriaEmpresa(AddEmpresaCategoriaDTO empresaCategoria)
        {

            var empresa = _context.Empresas.Find(empresaCategoria.IdEmpresa);

            if (empresa is null)
            {
                throw new Exception("La empresa ya no existe.");
            }

            var existingCategoriaEmpresa = _context.EmpresaCategorias
                .FirstOrDefault(ec => ec.IdCategoria == empresaCategoria.IdCategoria && ec.IdEmpresa == empresaCategoria.IdEmpresa);

            if (existingCategoriaEmpresa is null)
            {
                throw new Exception("La empresa ya no esta asociada a esa categoria.");
            }

            _context.EmpresaCategorias.Remove(existingCategoriaEmpresa);
            _context.SaveChanges();
        }

        // Método para quitar acentos
        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
