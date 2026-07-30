using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    public class UniversidadContext : DbContext
    {
        // Colección de alumnos (DbSet)
        public DbSet<Alumno> Alumnos { get; set; }

        public UniversidadContext()
        {
            // Se asegura de crear la base de datos si no existe
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración de la cadena de conexión a (localdb)
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Universidad;Integrated Security=true");

            // TIP: Imprimir en la consola el código SQL generado por el ORM
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}