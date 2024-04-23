using BDLosPanchos;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace LosPanchosDB
{
    public class LosPanchosContext : DbContext
    {
        public LosPanchosContext(DbContextOptions<LosPanchosContext> options)
            : base(options)
        {

        }

        public DbSet<Ruta> rutas { get; set; }
        public DbSet<Tiquete> tiquetes { get; set; }
        public DbSet<RutaRamal> rutasRamals { get; set; }
        public DbSet<Asiento> asientos { get; set; }
        public DbSet<Bus> buses { get; set; }
        public DbSet<Ramal> ramales { get; set; }
        public DbSet<Viaje> viajes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ruta>().ToTable("Ruta");
            modelBuilder.Entity<Tiquete>().ToTable("Tiquete");
            modelBuilder.Entity<RutaRamal>().ToTable("RutaRamal");
            modelBuilder.Entity<Asiento>().ToTable("Asiento");
            modelBuilder.Entity<Bus>().ToTable("Bus");
            modelBuilder.Entity<Ramal>().ToTable("Ramal");
            modelBuilder.Entity<Viaje>().ToTable("Viaje");
        }
    }
}