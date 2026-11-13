using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionUsuariosCETES.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Required, MaxLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Correo { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public bool Estado { get; set; } = true;

    // Navegación
    public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
}