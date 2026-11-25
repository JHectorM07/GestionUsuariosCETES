using GestionUsuariosCETES.Data;
using GestionUsuariosCETES.Models;
using System.Windows;
using System.Windows.Input;

namespace GestionUsuariosCETES.Views.auth
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            TxtUsuario.Focus();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string user = TxtUsuario.Text.Trim();
            string pass = TxtPassword.Password;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MostrarError("Por favor, completa todos los campos.");
                return;
            }

            try
            {
                using var db = new GestionUsuariosContext();
                var usuarioValido = db.Usuarios
                    .FirstOrDefault(u => u.Nombre == user && u.PasswordHash == pass);

                if (usuarioValido == null)
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                    return;
                }

                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo conectar con la base de datos: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            LblError.Text = mensaje;
            LblError.Visibility = Visibility.Visible;
            TxtPassword.Clear();
            TxtPassword.Focus();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
