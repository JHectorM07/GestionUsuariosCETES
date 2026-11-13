using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;
using System.Windows.Input;

public class HorarioCurso{

    [Key]
    public int IdHorarioCurso { get; set; }

    [ForeignKey("IdCurso")]
    [Required]
    public Curso Curso { get; set; } = new Curso();

    [Required]
    public DiaSemanaEnum DiaSemana { get; set; } = DiaSemanaEnum.Lunes;

    [Required]
    public string HoraInicio { get; set; } = string.Empty;

    [Required]
    public string HoraCierre { get; set; } = string.Empty;

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