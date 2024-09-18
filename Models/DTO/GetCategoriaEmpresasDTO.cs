namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class GetCategoriaEmpresasDTO


{
    [Key]
    public int IdCategoria { get; set; }
    [Required]
    public string? Nombre { get; set; }

 // Relación muchos a muchos
    public List<EmpresasCategoriaDTO>? EmpresaCategorias { get; set; }
}
