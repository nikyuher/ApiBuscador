namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class Peticion

{
    [Key]
    public int IdPeticion { get; set; }
    [Required]
    public string? NombreEmpresa { get; set; }
    [Required]
    public string? DescripcionEmpresa { get; set; }
    [Required]
    public string? DireccionEmpresa { get; set; }
    public string? ImagenEmpresaURL { get; set; }

    public int IdCategoriaEmpresa { get; set; }
    public int IdCiudadEmpresa { get; set; }

    // Relación con Usuario (muchos a uno)
    public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }
}
