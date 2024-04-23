using BDLosPanchos;
using LosPanchosDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ViajeController : ControllerBase
{
    private readonly LosPanchosContext context;

    public ViajeController(LosPanchosContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ViajeDTO>>> ObtenerViajesConRuta()
    {
        var viajes = await context.viajes
            .Include(v => v.RutaRamal)
                .ThenInclude(rr => rr.Ruta)
            .Include(v => v.RutaRamal)
                .ThenInclude(rr => rr.Ramal) // Incluir la relación con Ramal
            .ToListAsync();

        var viajesDTO = new List<ViajeDTO>();

        foreach (var viaje in viajes)
        {
            // Obtener el origen, destino y nombre del ramal de la ruta correspondiente
            var origen = viaje.RutaRamal.Ruta.origen;
            var destino = viaje.RutaRamal.Ruta.destino;
            var ramal = viaje.RutaRamal.Ramal.nombre; // Obtener el nombre del Ramal

            // Crear un DTO para el viaje con la información de la ruta y el ramal
            var viajeDTO = new ViajeDTO
            {
                Id = viaje.id,
                FechaViaje = viaje.fechaViaje,
                HoraViaje = viaje.horaViaje,
                DuracionMinutos = viaje.duracionMinutos,
                Origen = origen,
                Destino = destino,
                Ramal = ramal, // Asignar el nombre del Ramal al DTO
                               // Agregar otras propiedades si es necesario
            };

            viajesDTO.Add(viajeDTO);
        }

        return viajesDTO;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ViajeDTO>> ObtenerViajePorId(int id)
    {
        var viaje = await context.viajes
            .Where(v => v.id == id)
            .Include(v => v.RutaRamal)
                .ThenInclude(rr => rr.Ruta)
            .Include(v => v.RutaRamal)
                .ThenInclude(rr => rr.Ramal)
            .FirstOrDefaultAsync();

        if (viaje == null)
        {
            return NotFound(); // Si no se encuentra el viaje con el ID dado, devolver un error 404
        }

        var origen = viaje.RutaRamal.Ruta.origen;
        var destino = viaje.RutaRamal.Ruta.destino;
        var ramal = viaje.RutaRamal.Ramal.nombre;

        var viajeDTO = new ViajeDTO
        {
            Id = viaje.id,
            FechaViaje = viaje.fechaViaje,
            HoraViaje = viaje.horaViaje,
            DuracionMinutos = viaje.duracionMinutos,
            Origen = origen,
            Destino = destino,
            Ramal = ramal,
            BusID = viaje.busID // Añade la propiedad BusID al DTO
                                // Agregar otras propiedades si es necesario
        };

        return viajeDTO;
    }



}
