using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Business
{
    public interface IUsuarioService
    {
        //Get
        public List<UsuarioDTO> GetAll();
        public UsuarioDTO GetUsuarioId(int id);
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO);
        //Register
        public Usuario RegisterUsuario(RegisterUsuarioDTO user);
        //Update
        void UpdateUsuario(PutUsuarioDTO usuario);
        //Delete
        void DeleteUsuario(int idUsuario);
    }
}
