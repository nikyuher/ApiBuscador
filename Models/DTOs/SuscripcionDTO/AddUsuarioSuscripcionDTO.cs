namespace Buscador.Models
{
    public class AddUsuarioSuscripcionDTO
    {
        public int UsuarioId { get; set; }
        public int SuscripcionId { get; set; }
         public int DuracionMeses { get; set; }
        public bool EsActiva { get; set; }
    }
}
