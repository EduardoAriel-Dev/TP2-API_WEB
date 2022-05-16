using Microsoft.EntityFrameworkCore;
using PS.Template.Domain.Models;
using PS.Template.Domain.Settings;

namespace PS.Template.AccessData.DbContexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            //Contrustor por defecto.
        }
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }
        public DbSet<Alquileres> alquileres { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<EstadoDeAlquileres> estadoDeAlquileres { get; set; }
        public DbSet<Libros> libros { get; set; }
        protected override void OnModelCreating(ModelBuilder Modelos)
        {
            new SettingsAlquileres(Modelos.Entity<Alquileres>());
            new SettingsCliente(Modelos.Entity<Cliente>());
            new SettingsEstadoAlquiler(Modelos.Entity<EstadoDeAlquileres>());
            new SettingsLibro(Modelos.Entity<Libros>());

            base.OnModelCreating(Modelos);
            //Conexion con los Modemos (Es decir donde pones q datos tiene las tablas)
        }

        //Conexion a las tablas
    }
}
