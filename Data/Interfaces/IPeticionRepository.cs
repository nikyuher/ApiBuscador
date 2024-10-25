using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface IPeticionRepository
    {
        public List<PeticionDTO> GetAll();
        public AddPeticionDTO AddPeticion(AddPeticionDTO peticionDTO);
        Task AceptarPeticionAsync(int idPeticion);
        void DeletePeticion(int idPeticion);


    }
}
