using CarRental.Api.Data;
using CarRental.Api.Models;

namespace CarRental.Api
{
    public static class SeedData
    {
        
        public static void Initialize(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (context.Usuario.Any())
            {
                return;
            }
            var usuarios = new List<Usuario>
            {
                new Usuario { Nombre = "Juan Perez", Email = "Juan.Perwz@example.es"},
                new Usuario { Nombre = "Maria Gomez", Email = "maria.gomez@example.es"}
            };
            context.Usuario.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}