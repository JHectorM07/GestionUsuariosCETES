using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestionUsuariosCETES.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreCurso { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Lugar { get; set; }

        [Required]
        
        public DateTime FechaInicio { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaFin { get; set; } = DateTime.Now;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal PrecioTotal { get; set; }

        [Required]
        public bool Estado { get; set; } = true;

        // Navegación
        public ICollection<HorarioCurso> Horarios { get; set; } = new List<HorarioCurso>();
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    }
}