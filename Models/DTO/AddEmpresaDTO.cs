using System.ComponentModel.DataAnnotations;

namespace Buscador.Models;
public class AddEmpresaDTO
{
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public string? Direccion { get; set; }
    public string? Imagen { get; set; }


}