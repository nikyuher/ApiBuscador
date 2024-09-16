namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class Categoria


{
    [Key]
    public int IdCategoria { get; set; }
    [Required]
    public string? Nombre { get; set; }

 // Relación muchos a muchos
    public ICollection<EmpresaCategoria>? EmpresaCategorias { get; set; }
}