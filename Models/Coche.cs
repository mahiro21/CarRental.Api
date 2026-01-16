namespace CarRental.Api.Models
{
    public class Coche
    {
        public int Id {get; set;}

        public string Marca {get; set;} = string.Empty;

        public string Modelo {get; set;} = string.Empty;

        public decimal Precio {get; set;}

        public int AnyoFabricacion {get; set;}

        public ICollection<Alquiler> Alquileres {get; set;} // 1 : M
    }
}