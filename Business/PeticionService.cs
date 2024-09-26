using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Business
{
    public class PeticionService : IPeticionService
    {
        private readonly IPeticionRepository _peticionService;

        public PeticionService(IPeticionRepository peticionRepository)
        {
            _peticionService = peticionRepository;
        }


        //Get
        public List<PeticionDTO> GetAll() => _peticionService.GetAll();


        //Create
        public AddPeticionDTO AddPeticion(AddPeticionDTO peticionDTO)
        {
            return _peticionService.AddPeticion(peticionDTO);
        }

        public void AceptarPeticion(int idPeticion)
        {
            _peticionService.AceptarPeticion(idPeticion);
        }


        //Delete
        public void DeletePeticion(int idPeticion)
        {
            _peticionService.DeletePeticion(idPeticion);
        }
    }
}
