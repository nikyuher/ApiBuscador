using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface IUsuarioRepository
    {
        //Get
        public List<UsuarioDTO> GetAll();
        public UsuarioDTO GetUsuarioId(int id);
        public PeticionesUsuarioDTO GetPeticionesUsuarioId(int id);
        public EmpresasUsuarioDTO GetEmpresasUsuarioId(int id);
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO);
        //Create
        public Usuario RegisterUsuario(RegisterUsuarioDTO user);
        //Update
        void UpdateUsuario(PutUsuarioDTO usuario);
        //Delete
        void DeleteUsuario(int idUsuario);
        void DeleteEmpresaUsuario(int empresaUsuario);
    }
}
