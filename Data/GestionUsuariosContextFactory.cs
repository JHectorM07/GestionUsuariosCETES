using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GestionUsuariosCETES.Data
{
    public class GestionUsuariosContextFactory : IDesignTimeDbContextFactory<GestionUsuariosContext>
    {
        public GestionUsuariosContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var options = new DbContextOptionsBuilder<GestionUsuariosContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .Options;

            return new GestionUsuariosContext(options);
        }
    }
}
