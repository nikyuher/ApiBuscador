namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;

public class SuscripcionDatosDTO
{
    [Key]
    public int IdSuscripcion { get; set; }
    public string? TipoPlan { get; set; }
    public string? Descripcion { get; set; }
    public decimal Costo { get; set; }
}