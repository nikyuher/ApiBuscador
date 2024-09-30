namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioEmpresaDTO


{
    [Key]
    public int IdUsuarioEmpresa { get; set; }
    
    public int IdEmpresa { get; set; }
    public NameEmpresaDTO? Empresa { get; set; }

}