namespace CarRental.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public ICollection<Alquiler> Alquileres {get; set;} // M : 1



    }

}