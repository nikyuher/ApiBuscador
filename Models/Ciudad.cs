namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class Ciudad

{
    [Key]
    public int IdCiudad { get; set; }
    [Required]
    public string? Nombre { get; set; }

    public ICollection<EmpresaCiudad>? EmpresasCiudades { get; set; }
}