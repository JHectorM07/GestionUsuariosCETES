using GestionUsuariosCETES.Data;
using GestionUsuariosCETES.Models;
using System.Windows;

namespace GestionUsuariosCETES.Views.alumno
{
    public partial class AlumnoFormWindow : Window
    {
        public AlumnoFormWindow()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarnet.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos.");
                return;
            }

            using var db = new GestionUsuariosContext();
            db.Alumnos.Add(new Alumnos
            {
                Carnet = txtCarnet.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim()
            });
            db.SaveChanges();

            MessageBox.Show("¡Alumno guardado correctamente!");
            txtCarnet.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }
    }
}
