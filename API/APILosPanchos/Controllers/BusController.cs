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
    public class BusController : ControllerBase
    {

        private LosPanchosContext context;

        public BusController(LosPanchosContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<IEnumerable<Bus>> obtenerRutas()
        {
            return await context.buses.ToListAsync();
        }


        [HttpGet("{placa}")]
        public async Task<ActionResult<Bus>> ObtenerBusPorPlaca(string placa)
        {
            var bus = await context.buses.FindAsync(placa);

            if (bus == null)
            {
                return NotFound();
            }

            return bus;
        }

    }
}

