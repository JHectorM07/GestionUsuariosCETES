using GestionUsuariosCETES.Data;
using GestionUsuariosCETES.Models;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
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

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)) { 
                    LblError.Text = "Por favor, completa todos los campos.";
                    LblError.Visibility = Visibility.Visible;
                    return;
                }

                using var db = new GestionUsuariosContext();
                var usuarioValido = db.Usuarios
                    .FirstOrDefault(u => u.Nombre == user && u.PasswordHash == pass);

                if(usuarioValido == null)
                {
                    LblError.Text = "Usuario o contraseña incorrectos.";
                    LblError.Visibility = Visibility.Visible;
                    TxtPassword.Clear();
                    TxtPassword.Focus();
                }

                if (usuarioValido != null)
                {
                    var main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else {
                    LblError.Text = "Usuario o contraseña incorrectos";
                    LblError.Visibility = Visibility.Visible;
                    TxtPassword.Clear();
                    TxtPassword.Focus();
                }
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