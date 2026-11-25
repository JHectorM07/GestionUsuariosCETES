using System.ComponentModel.DataAnnotations;

namespace GestionUsuariosCETES.Models;

public class Alumnos
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Carnet { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Apellido { get; set; } = string.Empty;
}
