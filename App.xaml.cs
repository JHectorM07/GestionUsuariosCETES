using GestionUsuariosCETES.Data;
using GestionUsuariosCETES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace GestionUsuariosCETES
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                var options = new DbContextOptionsBuilder<GestionUsuariosContext>()
                    .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                    .Options;

                using var db = new GestionUsuariosContext(options);
                db.Database.Migrate(); // crea la BD si no existe y aplica migraciones
                SeedUsuario(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al inicializar la base de datos");
                Shutdown();
            }
        }

        private static void SeedUsuario(GestionUsuariosContext db)
        {
            if (db.Usuarios.Any())
                return;

            db.Usuarios.Add(new Usuario
            {
                Nombre = "admin",
                Correo = "admin@cetes.mx",
                PasswordHash = "admin123",
                Estado = true
            });
            db.SaveChanges();
        }
    }
}
