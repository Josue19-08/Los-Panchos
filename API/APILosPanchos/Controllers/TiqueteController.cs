using BDLosPanchos;
using LosPanchosDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILosPanchos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiqueteController : ControllerBase
    {
        private LosPanchosContext context;

        public TiqueteController(LosPanchosContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiqueteDTO>> ObtenerTiquetePorId(int id)
        {
            var tiquete = await context.tiquetes.FindAsync(id);

            if (tiquete == null)
            {
                return NotFound();
            }

            // Concatenar los asientos en una sola cadena

            var tiqueteDTO = new TiqueteDTO
            {
                id = tiquete.id,
                email = tiquete.email,
                viajeID = tiquete.viajeID,
                costo = tiquete.costo,
                asiento = tiquete.asiento // Asignar la cadena de asientos concatenados
            };

            return tiqueteDTO;
        }

        [HttpPost]
        public async Task<ActionResult<TiqueteDTO>> RegistrarTiquete(TiqueteDTO tiqueteDTO)
        {
            // Crear una nueva instancia de Tiquete a partir de los datos proporcionados en el DTO
            var nuevoTiquete = new Tiquete
            {
                email = tiqueteDTO.email,
                viajeID = tiqueteDTO.viajeID,
                costo = tiqueteDTO.costo,
                asiento = tiqueteDTO.asiento // Asignar directamente la cadena de asientos
            };

            // Agregar el nuevo tiquete al contexto y guardar los cambios en la base de datos
            context.tiquetes.Add(nuevoTiquete);
            await context.SaveChangesAsync();

            // Asignar el ID del tiquete al objeto DTO
            tiqueteDTO.id = nuevoTiquete.id;

            // Devolver una respuesta HTTP 201 (Created) con el DTO del tiquete registrado
            // y la URL de ubicación para obtener más detalles sobre el tiquete
            return CreatedAtAction(nameof(ObtenerTiquetePorId), new { id = nuevoTiquete.id }, tiqueteDTO);
        }



    }
}
