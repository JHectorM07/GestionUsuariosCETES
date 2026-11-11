using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestionUsuariosCETES.Models
{
    public enum EstadoInscripcionEnum
    {
        Activa = 1,
        Inactiva = 2,
    }

    public class Inscripcion
    {
        [Key]
        public int IdInscripcion { get; set; }

        public int IdCliente { get; set; }
        public int IdCurso { get; set; }

        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoAcordado { get; set; }

        
        public EstadoInscripcionEnum EstadoInscripcion { get; set; } = EstadoInscripcionEnum.Activa;

        // Propiedades de navegación 
        [ForeignKey(nameof(IdCliente))]
        public Cliente? Cliente { get; set; }

        [ForeignKey(nameof(IdCurso))]
        public Curso? Curso { get; set; }

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}