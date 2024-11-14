using System.ComponentModel.DataAnnotations;

namespace Buscador.Models;
public class PutDatosEmpresaDTO
{
    public int IdEmpresa { get; set; }
    public int IdUsuario { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Direccion { get; set; }
    public int Telefono { get; set; }
    public string? CorreoEmpresa { get; set; }
    public string? SitioWeb { get; set; }
    public string? Imagen { get; set; }
    

}
