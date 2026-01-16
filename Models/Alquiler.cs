using Microsoft.Extensions.Configuration.UserSecrets;

namespace CarRental.Api.Models
{
    public class Alquiler
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        public int IdCoche { get; set; }

        public Coche Coche { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime Fechafin { get; set; }
    }
}