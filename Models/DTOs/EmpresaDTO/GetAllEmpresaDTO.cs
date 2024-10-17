using System.ComponentModel.DataAnnotations;

namespace Buscador.Models;
public class GetAllEmpresaDTO
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

    public List<IdsEmpresaCategoriaDTO>? EmpresaCategorias { get; set; }
    public List<IdsEmpresaCiudadDTO>? EmpresasCiudades { get; set; }
}
