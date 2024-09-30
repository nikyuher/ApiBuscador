namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class PeticionesUsuarioDTO

{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public List<PeticionDTO> PeticionesDTO { get; set; } = new List<PeticionDTO>();
}
