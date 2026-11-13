using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;
using System.Windows.Input;
using GestionUsuariosCETES.Models;

public class HorarioCurso{

    [Key]
    public int IdHorario { get; set; }

   
    public int IdCurso { get; set; }

    [Required]
    public DiaSemanaEnum DiaSemana { get; set; } = DiaSemanaEnum.Lunes;

    [Required]
    public TimeSpan HoraInicio { get; set; } 

    [Required]
    public TimeSpan HoraFin{ get; set; }

    // Navegación
    [ForeignKey(nameof(IdCurso))]
    public Curso? Curso { get; set; }

    public enum DiaSemanaEnum{
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        
        Sabado = 6,
        Domingo = 7
    }
}