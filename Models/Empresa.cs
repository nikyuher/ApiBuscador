using System.ComponentModel.DataAnnotations;

namespace Buscador.Models;
public class Empresa
{
    [Key]
    public int IdEmpresa { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public string? Direccion { get; set; }
    public string? Imagen { get; set; }

    // Relación muchos a muchos
    public ICollection<EmpresaCategoria>? EmpresaCategorias { get; set; }
    public ICollection<EmpresaCiudad>? EmpresasCiudades { get; set; }

}
