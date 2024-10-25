namespace Buscador.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario

{
    [Key]
    public int IdUsuario { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? Nombre { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? Contrasena { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    [Column(TypeName = "varchar(255)")]
    public string? Correo { get; set; }
    
    public bool Rol { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? PasswordResetCode { get; set; }

    public DateTime? PasswordResetCodeExpiry { get; set; }
    public DateTime PasswordChangedAt { get; set; }
    public List<Peticion> Peticiones { get; set; } = new List<Peticion>();
    public List<UsuarioEmpresa> MisEmpresas { get; set; } = new List<UsuarioEmpresa>();
}
