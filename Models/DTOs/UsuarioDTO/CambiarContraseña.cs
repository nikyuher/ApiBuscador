using System.ComponentModel.DataAnnotations;
namespace Buscador.Models
{
    public class CambiarContrasenaDTO
    {
        [Required]
        public string? ContrasenaActual { get; set; }

        [Required]
        public string? NuevaContrasena { get; set; }

        [Required]
        [Compare("NuevaContrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        public string? ConfirmarContrasena { get; set; }
    }
}
