namespace Buscador.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RestablecerContrasenaDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Correo { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "El código debe tener exactamente 5 dígitos.")]
        public string Codigo { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "La nueva contraseña debe tener al menos 6 caracteres.")]
        public string NuevaContrasena { get; set; }

        [Required]
        [Compare("NuevaContrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContrasena { get; set; }
    }
}
