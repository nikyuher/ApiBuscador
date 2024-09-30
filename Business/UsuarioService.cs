using Buscador.Models;
using Buscador.Data;
using System.Collections.Generic;

namespace Buscador.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        //Get
        public List<UsuarioDTO> GetAll() => _usuarioRepository.GetAll();
        public UsuarioDTO GetUsuarioId(int id)
        {
            return _usuarioRepository.GetUsuarioId(id);
        }
        public PeticionesUsuarioDTO GetPeticionesUsuarioId(int id)
        {
            return _usuarioRepository.GetPeticionesUsuarioId(id);
        }
        public EmpresasUsuarioDTO GetEmpresasUsuarioId(int id)
        {
            return _usuarioRepository.GetEmpresasUsuarioId(id);
        }
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO)
        {
            return _usuarioRepository.LoginUsuario(loginDTO);
        }

        //Create
        public Usuario RegisterUsuario(RegisterUsuarioDTO user)
        {
            return _usuarioRepository.RegisterUsuario(user);
        }

        //Update
        public void UpdateUsuario(PutUsuarioDTO usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }


        //Delete
        public void DeleteUsuario(int idUsuario)
        {
            _usuarioRepository.DeleteUsuario(idUsuario);
        }

        public void DeleteEmpresaUsuario(int empresaUsuario){
            _usuarioRepository.DeleteEmpresaUsuario(empresaUsuario);

        }
    }
}
