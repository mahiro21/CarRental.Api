
using CarRental.Api.Data;
using CarRental.Api.Dto;
using CarRental.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CocheController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CocheController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocheDto>>> GetAllCoches()
        {
            var coches = await _context.Coches.ToListAsync();
            return coches.Select(ToDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CocheDto>> GetCocheById(int id)
        {
            var coche = await _context.Coches.FindAsync(id);
            return coche is null ? NotFound() : ToDto(coche);
        }


        [HttpPost]
        public async Task<ActionResult<CocheDto>> createCoche(CocheDto cocheDto)
        {
            isValidYear(cocheDto.AnyoFabricacion);

            var coche = ToEntity(cocheDto);
            _context.Coches.Add(coche);
            await _context.SaveChangesAsync();

            cocheDto.Id = coche.Id;
            return CreatedAtAction(nameof(GetCocheById), new { id = coche.Id }, cocheDto);
        }

        // [HttpPut("{id}")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCoche(int id, CocheDto cocheDto)
        {

            var coche = await _context.Coches.FindAsync(id);
            if (coche is null)
            {
                return NotFound();
            }
            isValidYear(cocheDto.AnyoFabricacion);

            coche.Marca = cocheDto.Marca;
            coche.Modelo = cocheDto.Modelo;
            coche.Precio = cocheDto.Precio;
            coche.AnyoFabricacion = cocheDto.AnyoFabricacion;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoche(int id)
        {
            var coche = await _context.Coches.FindAsync(id);
            if (coche is null)
            {
                return NotFound();
            }

            _context.Coches.Remove(coche);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Servicios a desplazar a la clase de Service
        private async Task<ActionResult<CocheDto>>? GetCoche(int id)
        {
            var coche = await _context.Coches.FindAsync(id);
            return coche is null ? null : Ok(ToDto(coche));
        }

        private Coche ToEntity(CocheDto cocheDto) => new Coche
        {
            Marca = cocheDto.Marca,
            Modelo = cocheDto.Modelo,
            Precio = cocheDto.Precio,
            AnyoFabricacion = cocheDto.AnyoFabricacion
        };

        private CocheDto ToDto(Coche coche) => new CocheDto
        {
            Id = coche.Id,
            Marca = coche.Marca,
            Modelo = coche.Modelo,
            Precio = coche.Precio,
            AnyoFabricacion = coche.AnyoFabricacion
        };


        private void isValidYear(int anyoFabricacion)
        {
            if (anyoFabricacion < DateTime.Now.Year - 5)
            {
                throw new ArgumentException("El coche no puede tener na antiguedad mayor a 5 años.");
            }


        }
    }

}