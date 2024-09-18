﻿using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using System.Collections.Generic;
using System.Linq;
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

        public List<Empresa> GetAll()
        {
            return _context.Empresas.ToList();
        }

        public List<Empresa> GetEmpresaNombre(string nombre)
        {
            // Normalizar y quitar acentos del término de búsqueda
            var normalizedNombre = RemoveDiacritics(nombre.ToLower());

            // Consultar todas las empresas
            var empresas = _context.Empresas
                .AsEnumerable() // Cambia la consulta a cliente para usar RemoveDiacritics
                .Where(e => RemoveDiacritics(e.Nombre.ToLower()).StartsWith(normalizedNombre))
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

        public void Update(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var empresa = _context.Empresas.Find(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                _context.SaveChanges();
            }
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
