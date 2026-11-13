using System.ComponentModel.DataAnnotations;

namespace GestionUsuariosCETES.Models;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Correo { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public bool Estado { get; set; } = true;
}