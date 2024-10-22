namespace Buscador.Models
{
    public class UsuarioSuscripcionDTO
    {
        public int IdUsuarioSuscripcion { get; set; }
        public PutUsuarioDTO? Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }
         public int DuracionMeses { get; set; }
        public bool EsActiva { get; set; }
    }
}
