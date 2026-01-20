using System.ComponentModel.DataAnnotations;

namespace CarRental.Api.Dto
{
    public class AlquilerDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdCoche { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime Fechafin { get; set; }
    }
}