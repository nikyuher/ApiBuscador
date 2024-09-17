﻿using Microsoft.EntityFrameworkCore;
using Buscador.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
