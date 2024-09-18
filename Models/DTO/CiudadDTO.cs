namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class CiudadDTO

{
    [Key]
    public int IdCiudad { get; set; }
    [Required]
    public string? Nombre { get; set; }

}
