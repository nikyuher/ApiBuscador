namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Categoria


{
    [Key]
    public int IdCategoria { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")] 
    public string? Nombre { get; set; }

 // Relación muchos a muchos
    public List<EmpresaCategoria>? EmpresaCategorias { get; set; }
}
