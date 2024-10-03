using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Buscador.Models;
public class DatosEmpresaDTO
{
    [Key]
    public int IdEmpresa { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Direccion { get; set; }
    public string? Imagen { get; set; }
}
