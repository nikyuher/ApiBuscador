namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
public class Usuario

{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Contrasena { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    public string Correo { get; set; }
    public bool Rol { get; set; }
    public bool Suscripcion { get; set; }
    public string? PasswordResetCode { get; set; }
    public DateTime? PasswordResetCodeExpiry { get; set; }
    public DateTime PasswordChangedAt { get; set; }
    public List<Peticion> Peticiones { get; set; } = new List<Peticion>();
    public List<UsuarioEmpresa> MisEmpresas { get; set; } = new List<UsuarioEmpresa>();
}
