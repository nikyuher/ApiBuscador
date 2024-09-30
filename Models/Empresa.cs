using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    public List<EmpresaCategoria>? EmpresaCategorias { get; set; }
    public List<EmpresaCiudad>? EmpresasCiudades { get; set; }
    public List<UsuarioEmpresa> UsuarioEmpresas { get; set; } = new List<UsuarioEmpresa>();
    [JsonIgnore]
    public Peticion? Peticion { get; set; }

}
