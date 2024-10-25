using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Business
{
    public interface IPeticionService
    {
        //GET
        public List<PeticionDTO> GetAll();
        //Post
        public AddPeticionDTO AddPeticion(AddPeticionDTO peticionDTO);
        Task AceptarPeticionAsync(int idPeticion);
        //Delete
        void DeletePeticion(int idPeticion);
    }
}
