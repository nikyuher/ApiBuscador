using Buscador.Models;
using System.Collections.Generic;

namespace Buscador.Data
{
    public interface IUsuarioRepository
    {
        public List<UsuarioDTO> GetAll();
        public UsuarioDTO GetUsuarioId(int id);
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO);
        public Usuario RegisterUsuario(RegisterUsuarioDTO user);
        void UpdateUsuario(PutUsuarioDTO usuario);
        void DeleteUsuario(int idUsuario);
    }
}
