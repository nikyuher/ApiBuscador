namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class PutUsuarioDTO

{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Correo { get; set; }
}
