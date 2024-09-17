﻿using Microsoft.EntityFrameworkCore;
using Buscador.Models;

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
            var empresas = _context.Empresas.ToList();

            return empresas;
        }
    }
}

