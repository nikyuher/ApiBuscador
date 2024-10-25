namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ciudad

{
    [Key]
    public int IdCiudad { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? Nombre { get; set; }

    public List<EmpresaCiudad>? EmpresasCiudades { get; set; }
}
