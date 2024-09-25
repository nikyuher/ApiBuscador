namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class LoginUsuarioDTO

{
    [Required]
    public string? Correo { get; set; }
    [Required]
    public string? Contrasena { get; set; }
}
