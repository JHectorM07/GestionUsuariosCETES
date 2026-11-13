using GestionUsuariosCETES.Data;
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
        var ingresosTotalesMes = db.Pagos.Where(p => p.FechaPago.Month == DateTime.Now.Month && p.FechaPago.Year == DateTime.Now.Year)
            .Sum(p => (decimal?)p.Monto) ?? 0;

        TxtTotalAlumnos.Text = clientesTotales.ToString();
        TxtCursosActivos.Text = cursosTotales.ToString();
    }
}
