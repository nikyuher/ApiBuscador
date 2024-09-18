using System.ComponentModel.DataAnnotations;

namespace Buscador.Models;
public class NameEmpresaDTO
{
    [Key]
    public int IdEmpresa { get; set; }
    [Required]
    public string? Nombre { get; set; }


}
