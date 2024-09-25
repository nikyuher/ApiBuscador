namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class AddPeticionDTO

{
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public string? NombreEmpresa { get; set; }
    [Required]
    public string? DescripcionEmpresa { get; set; }
    [Required]
    public string? DireccionEmpresa { get; set; }
    public string? ImagenEmpresaURL { get; set; }
    [Required]
    public int IdCategoriaEmpresa { get; set; }
    [Required]
    public int IdCiudadEmpresa { get; set; }
}
