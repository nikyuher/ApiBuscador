namespace Buscador.Models
{
    public class SuscripcionDTO
    {
        public int IdSuscripcion { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? TipoPlan { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public decimal Costo { get; set; }
    }
}