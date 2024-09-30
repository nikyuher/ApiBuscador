namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class DeleteUsuarioEmpresaDTO


{
    [Key]
    public int IdUsuarioEmpresa { get; set; }
    public int IdUsuario { get; set; }

}