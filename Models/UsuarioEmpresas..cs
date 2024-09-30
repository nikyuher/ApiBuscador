namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioEmpresa


{
    [Key]
    public int IdUsuarioEmpresa { get; set; }
    
    public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }

    public int IdEmpresa { get; set; }
    public Empresa? Empresa { get; set; }

}