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
        [StringLength(100)]
        public string NombreCurso { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Lugar { get; set; }

        [Required]
        
        public DateTime FechaInicio { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaCierre { get; set; } = DateTime.Now;

        [Required]
        public int PrecioTotal { get; set; }

        [Required]
        public MetodoEstadoEnum MetodoEstado { get; set; } = MetodoEstadoEnum.activo;

        public enum MetodoEstadoEnum{
            activo = 1,
            inactivo = 2
        }
    }
}