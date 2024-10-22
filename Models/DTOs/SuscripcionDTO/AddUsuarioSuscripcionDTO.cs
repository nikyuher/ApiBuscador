namespace Buscador.Models
{
    public class AddUsuarioSuscripcionDTO
    {
        public int IdUsuarioSuscripcion { get; set; }
        public int UsuarioId { get; set; }
        public int SuscripcionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }
         public int DuracionMeses { get; set; }
        public bool EsActiva { get; set; }
    }
}
