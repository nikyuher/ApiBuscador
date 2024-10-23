using System.ComponentModel.DataAnnotations;

namespace Buscador.Models
{
    public class UsuarioSuscripcion
    {
        [Key]
        public int IdUsuarioSuscripcion { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        [Required]
        public int SuscripcionId { get; set; }
        public Suscripcion? Suscripcion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }
        [Required]
        public int DuracionMeses { get; set; }
        public bool EsActiva { get; set; }
    }
}
