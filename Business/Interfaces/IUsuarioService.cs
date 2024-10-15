using Buscador.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Buscador.Business
{
    public interface IUsuarioService
    {
        //Get
        public List<UsuarioDTO> GetAll();
        public UsuarioDTO GetUsuarioId(int id);
        public PeticionesUsuarioDTO GetPeticionesUsuarioId(int id);
        public EmpresasUsuarioDTO GetEmpresasUsuarioId(int id);
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO);
        //Register
        public Usuario RegisterUsuario(RegisterUsuarioDTO user);
        //Update
        void UpdateUsuario(PutUsuarioDTO usuario);
        void CambiarContrasena(int idUsuario, CambiarContrasenaDTO request);
        //Delete
        void DeleteUsuario(int idUsuario);
        void DeleteEmpresaUsuario(int empresaUsuario);

        //Email
        Task SolicitarRecuperacionAsync(SolicitarRecuperacionDTO request);
        Task VerificarCodigoAsync(VerificarCodigoDTO codigoDTO);
        Task CambiarContrasenaConCodigoAsync(RestablecerContrasenaDTO request);
    }
}
