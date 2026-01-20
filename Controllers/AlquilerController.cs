using System.Net;
using CarRental.Api.Data;
using CarRental.Api.Dto;
using CarRental.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlquilerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AlquilerController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlquilerDto>>> GetAllAlquileres()
        {
            var alquileres = await _context.Alquiler.ToListAsync();
            return alquileres.Select(ToDto).ToList();
        }



        [HttpPost]
        public async Task<ActionResult> CreateAlquiler([FromBody] AlquilerDto alquilerDto)
        {
            if (alquilerDto.FechaInicio >= alquilerDto.Fechafin)
            {
                return BadRequest("Periodo de alquiler invalido.");
            }

            var coche = await _context.Coches.FindAsync(alquilerDto.IdCoche);
            if (coche is null)
            {
                Console.WriteLine("Coche no encontrado con Id: " + alquilerDto.IdCoche);
                return NotFound("Coche no encontrado.");
            }

            bool cocheDisponible = !_context.Alquiler
                .Any(a => a.IdCoche == alquilerDto.IdCoche &&
                          ((alquilerDto.FechaInicio >= a.FechaInicio && alquilerDto.FechaInicio < a.Fechafin) ||
                           (alquilerDto.Fechafin > a.FechaInicio && alquilerDto.Fechafin <= a.Fechafin) ||
                           (alquilerDto.FechaInicio <= a.FechaInicio && alquilerDto.Fechafin >= a.Fechafin)));

            if (!cocheDisponible)
            {
                return Conflict("El coche no está disponible en las fechas seleccionadas.");
            }

            var totalDias = (alquilerDto.Fechafin - alquilerDto.FechaInicio).Days;
            if (totalDias <= 0)
            {
                return BadRequest("El periodo de alquiler debe ser al menos de un día.");
            }
            var totalCoste = totalDias * coche.Precio;

            var alquiler = new Alquiler
            {
                IdUsuario = alquilerDto.IdUsuario,
                IdCoche = alquilerDto.IdCoche,
                FechaInicio = alquilerDto.FechaInicio,
                Fechafin = alquilerDto.Fechafin,
                // CosteTotal = totalCoste
            };

            _context.Alquiler.Add(alquiler);
            await _context.SaveChangesAsync();

            return Ok(new { alquiler.Id, TotalCoste = totalCoste });
        }

        private AlquilerDto ToDto(Alquiler alquiler)
        {
            return new AlquilerDto
            {
                Id = alquiler.Id,
                IdUsuario = alquiler.IdUsuario,
                IdCoche = alquiler.IdCoche,
                FechaInicio = alquiler.FechaInicio,
                Fechafin = alquiler.Fechafin
            };
        }

    }





}