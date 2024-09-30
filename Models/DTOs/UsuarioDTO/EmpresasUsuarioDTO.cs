namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class EmpresasUsuarioDTO

{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public string? Nombre { get; set; }
    public List<UsuarioEmpresaDTO> MisEmpresas { get; set; } = new List<UsuarioEmpresaDTO>();
}
