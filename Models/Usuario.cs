namespace CarRental.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public ICollection<Alquiler> Alquileres {get; set;} // M : 1



    }

}