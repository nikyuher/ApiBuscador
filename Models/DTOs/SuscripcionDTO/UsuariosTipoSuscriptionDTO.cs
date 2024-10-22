namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;

public class UsuarioTipoSuscripcionDTO
{
    [Key]
    public int IdSuscripcion { get; set; }
    public string? TipoPlan { get; set; }
    public List<UsuarioSuscripcionDTO> UsuarioSuscripciones { get; set; } = new List<UsuarioSuscripcionDTO>();
}