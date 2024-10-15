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
        public void CambiarContrasena(int idUsuario, CambiarContrasenaDTO request);
        //Delete
        void DeleteUsuario(int idUsuario);
        void DeleteEmpresaUsuario(int empresaUsuario);

        //Emaik
        Task EstablecerCodigoRecuperacionAsync(string correo, string codigo, DateTime expiracion);
        Task<Usuario?> ObtenerUsuarioPorCorreoAsync(string correo);
        Task RestablecerContrasenaAsync(string correo, string nuevaContrasena);
    }
}
