namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class RegisterUsuarioDTO

{
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Contrasena { get; set; }
    [Required]
    public string? Correo { get; set; }
}
