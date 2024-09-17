namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class UpdateCategoriaDTO


{
    [Key]
    public int IdCategoria { get; set; }
    [Required]
    public string? Nombre { get; set; }

}
