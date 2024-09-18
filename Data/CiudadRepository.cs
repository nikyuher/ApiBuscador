using Microsoft.EntityFrameworkCore;
using Buscador.Models;

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
                Nombre = ciudad.Nombre
            };

            return ciudadaDTO;
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

