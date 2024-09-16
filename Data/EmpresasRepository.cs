﻿using Microsoft.EntityFrameworkCore;
using Buscador.Models;

namespace Buscador.Data
{
    public class EmpresaRepository : IEmpresaRepository
{
        private readonly BuscadorAppContext _context;

        public EmpresaRepository (BuscadorAppContext context)
        {
            _context = context;
        }

        public List<Empresa> GetAll()
        {
            return _context.Empresas.ToList();
        }
    }
}

