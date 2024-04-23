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
    public class RutaRamalController : ControllerBase
    {
        private LosPanchosContext context;

        public RutaRamalController(LosPanchosContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RutaRamal>> ObtenerRutaRamalPorId(int id)
        {
            var rutaRamal = await context.rutasRamals.FindAsync(id);

            if (rutaRamal == null)
            {
                return NotFound();
            }

            return rutaRamal;
        }
    }
}
