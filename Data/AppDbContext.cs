using CarRental.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Usuario> Usuario {get; set;}

        public DbSet<Coche> Coches {get; set;}

        public DbSet<Alquiler> Alquiler {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coche>()
            .Property(c => c.Precio)
            .HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder); // 18 dígitos + 2 decimales 
        }

    }
}