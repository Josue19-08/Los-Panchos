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
    public class RamalController : ControllerBase
    {
        private LosPanchosContext context;

        public RamalController(LosPanchosContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ramal>> ObtenerRamalPorId(int id)
        {
            var ramal = await context.ramales.FindAsync(id);

            if (ramal == null)
            {
                return NotFound();
            }

            return ramal;
        }
    }
}
