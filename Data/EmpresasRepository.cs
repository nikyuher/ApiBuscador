﻿using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using System.Text;
using System.Globalization;
using System.IO.Compression;

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

            if ( _context.Empresas.Any(e => e.Nombre == empresa.Nombre))
            {
                throw new Exception($"Ya existe una empresa con el nombre {empresa.Nombre}");
            }

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

        public EmpresaCiudad AddCiudadEmpresa(EmpresaCiudadDTO empresaCiudad)
        {
            var existingCiudadEmpresa = _context.EmpresasCiudades
                .FirstOrDefault(ec => ec.IdCiudad == empresaCiudad.IdCiudad && ec.IdEmpresa == empresaCiudad.IdEmpresa);

            if (existingCiudadEmpresa != null)
            {
                throw new Exception("La empresa ya está asociada a esta ciudad.");
            }

            var newCiudadEmpresa = new EmpresaCiudad
            {
                IdCiudad = empresaCiudad.IdCiudad,
                IdEmpresa = empresaCiudad.IdEmpresa
            };

            _context.EmpresasCiudades.Add(newCiudadEmpresa);
            _context.SaveChanges();

            return newCiudadEmpresa;
        }

        //Update
        public void Update(PutDatosEmpresaDTO empresaDto)
        {
            var existingEmpresa = _context.Empresas.FirstOrDefault(e => e.IdEmpresa == empresaDto.IdEmpresa);

            if (existingEmpresa != null)
            {
                existingEmpresa.Nombre = empresaDto.Nombre;
                existingEmpresa.Descripcion = empresaDto.Descripcion;
                existingEmpresa.Direccion = empresaDto.Direccion;
                existingEmpresa.Imagen = empresaDto.Imagen;

                _context.Entry(existingEmpresa).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("La empresa no existe");
            }
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
                throw new Exception("La empresa puesta ya no existe.");
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

        public void DeleteCiudadEmpresa(EmpresaCiudadDTO empresaCiudad)
        {

            var empresa = _context.Empresas.Find(empresaCiudad.IdEmpresa);

            if (empresa is null)
            {
                throw new Exception("La empresa puesta no existe.");
            }

            var existingCiudadEmpresa = _context.EmpresasCiudades
                .FirstOrDefault(ec => ec.IdCiudad == empresaCiudad.IdCiudad && ec.IdEmpresa == empresaCiudad.IdEmpresa);

            if (existingCiudadEmpresa is null)
            {
                throw new Exception("La empresa ya no esta asociada a esa ciudad.");
            }

            _context.EmpresasCiudades.Remove(existingCiudadEmpresa);
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
