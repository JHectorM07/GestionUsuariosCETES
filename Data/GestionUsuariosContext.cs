using GestionUsuariosCETES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace GestionUsuariosCETES.Data
{
    public class GestionUsuariosContext : DbContext
    {
        public GestionUsuariosContext()
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        public DbSet<HorarioCurso> HorariosCurso { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación explícita: Un Curso tiene muchos Horarios
            modelBuilder.Entity<HorarioCurso>()
                .HasOne(h => h.Curso)
                .WithMany(c => c.Horarios)
                .HasForeignKey(h => h.IdCurso) // Si tu propiedad se llama CursoId, cámbialo aquí
                .OnDelete(DeleteBehavior.Cascade);

            // Conversiones de Enums a string
            modelBuilder.Entity<HorarioCurso>()
                .Property(h => h.DiaSemana)
                .HasConversion<string>();

            modelBuilder.Entity<Inscripcion>()
                .Property(i => i.EstadoInscripcion)
                .HasConversion<string>();

            modelBuilder.Entity<Pago>()
                .Property(p => p.MetodoPago)
                .HasConversion<string>();
        }
    }
}
