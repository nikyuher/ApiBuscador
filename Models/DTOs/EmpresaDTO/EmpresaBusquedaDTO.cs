using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Buscador.Models;
public class EmpresaBusquedaDTO
{
    public int IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Direccion { get; set; }

    public int Telefono { get; set; }
    public string? Imagen { get; set; }
    public string? NombreCiudad { get; set; }

}
