using GestionUsuariosCETES.Data;
using System;
using System.Linq;
using System.Windows.Controls;

namespace GestionUsuariosCETES.Views.dashboard;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
        CargarDatosDashboard();
    }

    public void CargarDatosDashboard()
    {
        using var db = new GestionUsuariosContext();

        var clientesTotales = db.Clientes.Count();
        var cursosTotales = db.Cursos.Count();

        var ingresosTotalesMes = db.Pagos
            .Where(p => p.FechaPago.Month == DateTime.Now.Month && p.FechaPago.Year == DateTime.Now.Year)
            .Sum(p => (decimal?)p.Monto) ?? 0;

        var totalAcordado = db.Inscripciones
            .Where(i => i.EstadoInscripcion == Models.EstadoInscripcionEnum.Activa)
            .Sum(i => (decimal?)i.MontoAcordado) ?? 0;

        var totalAbonado = db.Pagos
            .Where(p => p.Inscripcion.EstadoInscripcion == Models.EstadoInscripcionEnum.Activa)
            .Sum(p => (decimal?)p.Monto) ?? 0;

        var saldosPendientes = totalAcordado - totalAbonado;

        TxtTotalAlumnos.Text = clientesTotales.ToString();
        TxtCursosActivos.Text = cursosTotales.ToString();
        TxtSaldosPendientes.Text = saldosPendientes.ToString("C2");
        TxtIngresosMes.Text = ingresosTotalesMes.ToString("C2");

        // Consulta para la tabla de Últimos Abonos Registrados
        var ultimosPagos = db.Pagos
            .OrderByDescending(p => p.FechaPago)
            .Take(10)
            .Select(p => new
            {
                FechaPago = p.FechaPago,
                NombreAlumno = p.Inscripcion.Cliente.Nombres + " " + p.Inscripcion.Cliente.Apellidos,
                NombreCurso = p.Inscripcion.Curso.NombreCurso,
                MetodoPago = p.MetodoPago,
                Monto = p.Monto
            })
            .ToList();

        GridUltimosPagos.ItemsSource = ultimosPagos;
        TxtFechaActual.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM yyyy");
    }
}