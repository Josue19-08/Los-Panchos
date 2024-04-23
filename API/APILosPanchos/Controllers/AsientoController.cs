using BDLosPanchos;
using LosPanchosDB;
using APILosPanchos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APILosPanchos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {

        private LosPanchosContext context;

        public AsientoController(LosPanchosContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asiento>> ObtenerAsientoPorId(int id)
        {
            var asiento = await context.asientos.FindAsync(id);

            if (asiento == null)
            {
                return NotFound();
            }

            return asiento;
        }

        [HttpGet("PorBus/{idBus}")]
        public async Task<ActionResult<IEnumerable<Asiento>>> ObtenerAsientosPorIdBus(string idBus)
        {
            var asientos = await context.asientos
                .Where(a => a.busID == idBus)
                .ToListAsync();

            if (asientos == null || !asientos.Any())
            {
                return NotFound();
            }

            return asientos;
        }

        [HttpPut("{numAsiento}")]
        public async Task<IActionResult> EditarAsiento(int numAsiento, AsientoDTO asientoDTO)
        {
            // Buscar el asiento por su número de asiento y el ID del bus
            var asiento = await context.asientos.FirstOrDefaultAsync(a => a.numAsiento == numAsiento && a.busID == asientoDTO.busID);

            // Si el asiento no existe, devolver NotFound
            if (asiento == null)
            {
                return NotFound();
            }

            // Actualizar las propiedades del asiento con los valores del DTO
            asiento.tiqueteID = asientoDTO.tiqueteID;

            try
            {
                await context.SaveChangesAsync();
                return NoContent(); // Devolver NoContent si la operación fue exitosa
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejar excepción de concurrencia
                return StatusCode(500); // Devolver un código de error 500 en caso de error de concurrencia
            }
        }






    }
}

