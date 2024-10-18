namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;

public class Suscripcion
{
    [Key]
    public int IdSuscripcion { get; set; }

public List<UsuarioSuscripcion> UsuarioSuscripciones { get; set; } = new List<UsuarioSuscripcion>();

    public DateTime FechaInicio { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public int DuracionMeses { get; set; }
    public string TipoPlan { get; set; }
    public decimal Costo { get; set; }
}