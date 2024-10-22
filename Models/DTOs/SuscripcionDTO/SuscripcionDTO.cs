namespace Buscador.Models
{
    public class SuscripcionDTO
    {
        public int IdSuscripcion { get; set; }
        public string? TipoPlan { get; set; }
            public string? Descripcion { get; set; }
        public decimal Costo { get; set; }
    }
}