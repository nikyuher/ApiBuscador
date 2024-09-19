namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class GetEmpresaCiudadDTO

{
    [Key]
    public int IdCiudad { get; set; }
    [Required]
    public string? Nombre { get; set; }

    public List<NameEmpresaCiudadDTO>? EmpresasCiudades { get; set; }
}
