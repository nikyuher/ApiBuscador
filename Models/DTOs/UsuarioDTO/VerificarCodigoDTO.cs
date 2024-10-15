namespace Buscador.Models
{
    using System.ComponentModel.DataAnnotations;

    public class VerificarCodigoDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Correo { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "El código debe tener exactamente 5 dígitos.")]
        public string Codigo { get; set; }
    }
}
