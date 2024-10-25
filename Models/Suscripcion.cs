namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;

public class Suscripcion
{
    [Key]
    public int IdSuscripcion { get; set; }
    public string? TipoPlan { get; set; }
    public string? Descripcion { get; set; }
    public decimal Costo { get; set; }
    public List<UsuarioSuscripcion> UsuarioSuscripciones { get; set; } = new List<UsuarioSuscripcion>();
}