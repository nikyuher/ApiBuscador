namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Peticion

{
    [Key]
    public int IdPeticion { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? NombreEmpresa { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string? DescripcionEmpresa { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? DireccionEmpresa { get; set; }

    [Required]
    public int TelefonoEmpresa { get; set; }

    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    [Column(TypeName = "varchar(255)")]
    public string? CorreoEmpresa { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? SitioWebEmpresa { get; set; }

    public string? ImagenEmpresaURL { get; set; }

    public int IdCategoriaEmpresa { get; set; }
    public int IdCiudadEmpresa { get; set; }

    // Relación con Usuario (muchos a uno)
    public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }
}
