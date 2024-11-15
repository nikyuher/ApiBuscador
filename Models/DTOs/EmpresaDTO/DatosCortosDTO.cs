using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Buscador.Models;
public class DatosCortosDTO
{
    [Key]
    public int IdEmpresa { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Direccion { get; set; }
    public int Telefono { get; set; }
     public string? Imagen { get; set; }
}
