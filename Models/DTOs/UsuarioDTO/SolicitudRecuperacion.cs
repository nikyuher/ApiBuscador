namespace Buscador.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SolicitarRecuperacionDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Correo { get; set; }
    }
}
