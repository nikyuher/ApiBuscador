namespace Buscador.Models
{
    public class UsuarioSuscripcion
    {
        public int IdUsuarioSuscripcion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int SuscripcionId { get; set; }
        public Suscripcion? Suscripcion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool EsActiva { get; set; }
    }
}