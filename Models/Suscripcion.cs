namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Suscripcion
{
    [Key]
    public int IdSuscripcion { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? TipoPlan { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Costo { get; set; }
    public List<UsuarioSuscripcion> UsuarioSuscripciones { get; set; } = new List<UsuarioSuscripcion>();
}