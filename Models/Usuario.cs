namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class Usuario

{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public string? Nombre { get; set; }
    public bool Rol { get; set; }
    public List<Peticion> Peticiones { get; set; } = new List<Peticion>();
}
