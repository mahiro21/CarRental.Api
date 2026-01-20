using System.ComponentModel.DataAnnotations;

namespace CarRental.Api.Dto
{
    public class CocheDto
    {   
        [Required]
        public int Id { get; set; }
        [Required]
        public string Marca { get; set; } = string.Empty;
        [Required]
        public string Modelo { get; set; } = string.Empty;
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int AnyoFabricacion { get; set; }
    }
}