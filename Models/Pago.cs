using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace GestionUsuariosCETES.Models
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }
        public int IdInscripcion { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }
        [Required]
        public MetodoPagoEnum MetodoPago { get; set; } = MetodoPagoEnum.Efectivo;

        // Propiedades de navegación 
        [ForeignKey(nameof(IdInscripcion))]
        public Inscripcion? Inscripcion { get; set; }
    }
    public enum MetodoPagoEnum { 
        Efectivo = 1,
        Tarjeta = 2
    }
}
