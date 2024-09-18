namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class AddCategoriaDTO


{
    [Required]
    public string? Nombre { get; set; }

}
