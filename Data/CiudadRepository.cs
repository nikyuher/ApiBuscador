using Buscador.Models;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Buscador.Data
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly BuscadorContext _context;

        public CiudadRepository(BuscadorContext context)
        {
            _context = context;
        }

        //Get
        public List<Ciudad> GetAll()
        {
            var ciudades = _context.Ciudadades.ToList();

            return ciudades;
        }


        public CiudadDTO GetCiudad(string nombre)
        {
            var ciudad = _context.Ciudadades.FirstOrDefault(c => c.Nombre == nombre);

            if (ciudad == null)
            {
                throw new Exception($"No se encontró la ciudad con el nombre: {nombre}");
            }

            var ciudadaDTO = new CiudadDTO
            {
                IdCiudad = ciudad.IdCiudad,
                Nombre = ciudad.Nombre
            };

            return ciudadaDTO;
        }

        public List<CiudadDTO> BuscadorCiudadNombre(string nombre)
        {
            var normalizedNombre = RemoveDiacritics(nombre.ToLower());

            var ciudades = _context.Ciudadades
                .AsEnumerable() // Trae todos los datos en memoria
                .Where(e => RemoveDiacritics(e.Nombre.ToLower()).Contains(normalizedNombre))
                .OrderBy(e => RemoveDiacritics(e.Nombre.ToLower()).IndexOf(normalizedNombre))
                .Select(e => new CiudadDTO
                {
                    IdCiudad = e.IdCiudad,
                    Nombre = e.Nombre
                })
                .ToList();

            if (!ciudades.Any())
            {
                throw new Exception($"No existe una ciudad con un nombre relacionado a {nombre}");
            }

            return ciudades;
        }


        public CiudadDTO GetCiudadId(int idCiudad)
        {
            var ciudad = _context.Ciudadades.FirstOrDefault(c => c.IdCiudad == idCiudad);

            if (ciudad == null)
            {
                throw new Exception($"No se encontró la ciudad con el ID: {idCiudad}");
            }

            var ciudadaDTO = new CiudadDTO
            {
                IdCiudad = ciudad.IdCiudad,
                Nombre = ciudad.Nombre
            };

            return ciudadaDTO;
        }

        public GetEmpresaCiudadDTO GetEmpresasCiudad(int id)
        {
            var ciudad = _context.Ciudadades
                .Include(c => c.EmpresasCiudades)
                .ThenInclude(ec => ec.Empresa)
                .FirstOrDefault(c => c.IdCiudad == id);

            if (ciudad is null)
            {
                throw new Exception($"Ciudad con ID {id} no encontrada.");
            }

            var ciudadDTO = new GetEmpresaCiudadDTO
            {
                IdCiudad = ciudad.IdCiudad,
                Nombre = ciudad.Nombre,
                EmpresasCiudades = ciudad.EmpresasCiudades.Select(ec => new NameEmpresaCiudadDTO
                {
                    IdEmpresaCiudad = ec.IdEmpresaCiudad,
                    Empresa = new NameEmpresaDTO
                    {
                        IdEmpresa = ec.Empresa.IdEmpresa,
                        Nombre = ec.Empresa.Nombre
                    }
                }).ToList()
            };

            return ciudadDTO;
        }

        public GetEmpresaCiudadDTO GetEmpresaCiudad(int idEmpresa, int idCiudad)
        {
            var ciudad = _context.Ciudadades
                .Include(c => c.EmpresasCiudades)
                .ThenInclude(ec => ec.Empresa)
                .FirstOrDefault(c => c.IdCiudad == idCiudad);

            // Si la ciudad no se encuentra, lanzar excepcio
            if (ciudad is null)
            {
                throw new Exception($"Ciudad con ID {idCiudad} no encontrada.");
            }

            // Si la empresa no se encuentra, lanzar excepcion
            var empresa = _context.Empresas.FirstOrDefault(e => e.IdEmpresa == idEmpresa);

            if (empresa is null)
            {
                throw new Exception($"Empresa con ID {idEmpresa} no encontrada.");
            }

            // Buscar si la empresa existe en la ciudad
            var empresaCiudad = ciudad.EmpresasCiudades
                .FirstOrDefault(ec => ec.Empresa.IdEmpresa == idEmpresa);

            // Si no se encuentra la empresa en la ciudad, lanzar excepcion o devolver un mensaje
            if (empresaCiudad is null)
            {
                throw new Exception($"No hay ninguna empresa con ID {idEmpresa} en la ciudad con ID {idCiudad}.");
            }

            // Crear el DTO con la información de la ciudad y la empresa encontrada
            var ciudadDTO = new GetEmpresaCiudadDTO
            {
                IdCiudad = ciudad.IdCiudad,
                Nombre = ciudad.Nombre,
                EmpresasCiudades = new List<NameEmpresaCiudadDTO>
        {
            new NameEmpresaCiudadDTO
            {
                IdEmpresaCiudad = empresaCiudad.IdEmpresaCiudad,
                Empresa = new NameEmpresaDTO
                {
                    IdEmpresa = empresaCiudad.Empresa.IdEmpresa,
                    Nombre = empresaCiudad.Empresa.Nombre
                }
            }
        }
            };

            return ciudadDTO;
        }


        //Create 

        public Ciudad CreateCiudad(CiudadDTO ciudad)
        {

            var newCiudad = new Ciudad
            {
                Nombre = ciudad.Nombre,
            };

            _context.Ciudadades.Add(newCiudad);
            SaveChanges();

            return newCiudad;
        }
        //Update
        public void UpdateCiudad(CiudadDTO ciudadDTO)
        {
            var existingCiudad = _context.Ciudadades.Find(ciudadDTO.IdCiudad);
            if (existingCiudad == null)
            {
                throw new KeyNotFoundException("No se encontró la ciudad a actualizar.");
            }

            existingCiudad.Nombre = ciudadDTO.Nombre;

            _context.Entry(existingCiudad).CurrentValues.SetValues(ciudadDTO);
            SaveChanges();
        }

        //Delete
        public void DeleteCiudad(int idCiudad)
        {

            var ciudad = _context.Ciudadades.FirstOrDefault(c => c.IdCiudad == idCiudad);

            if (ciudad is null)
            {
                throw new Exception($"No se encontro una ciudad con el ID: {idCiudad}");
            }

            _context.Ciudadades.Remove(ciudad);
            SaveChanges();

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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

