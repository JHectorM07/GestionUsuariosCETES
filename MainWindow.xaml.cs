using GestionUsuariosCETES.Views.auth;
using GestionUsuariosCETES.Views.dashboard;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionUsuariosCETES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Al abrir MainWindow, cargamos inmediatamente el Dashboard
            ContenedorVistas.Content = new DashboardView();
        }

        private void NavInicio_Checked(object sender, RoutedEventArgs e)
        {
            // Esta validación evita errores mientras la ventana termina de dibujarse
            if (ContenedorVistas != null)
                ContenedorVistas.Content = new DashboardView();
        }

        private void NavAlumnos_Checked(object sender, RoutedEventArgs e)
        {
            // Aquí cargarás ClientesView() cuando la crees:
            // ContenedorVistas.Content = new ClientesView();
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}