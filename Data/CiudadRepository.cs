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

