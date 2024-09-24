namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioDTO

{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public string? Nombre { get; set; }
    public bool Rol { get; set; }
    public List<PeticionDTO> PeticionesDTO { get; set; } = new List<PeticionDTO>();
}
