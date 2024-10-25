using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Buscador.Models;
public class Empresa
{
    [Key]
    public int IdEmpresa { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? Nombre { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? Direccion { get; set; }

    [Required]
    public int Telefono { get; set; }

    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    [Column(TypeName = "varchar(255)")]
    public string? CorreoEmpresa { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? SitioWeb { get; set; }
    public string? Imagen { get; set; }

    // Relación muchos a muchos
    public List<EmpresaCategoria>? EmpresaCategorias { get; set; }
    public List<EmpresaCiudad>? EmpresasCiudades { get; set; }
    public List<UsuarioEmpresa> UsuarioEmpresas { get; set; } = new List<UsuarioEmpresa>();
    [JsonIgnore]
    public Peticion? Peticion { get; set; }

}
