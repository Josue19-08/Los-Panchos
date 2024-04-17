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
    public class RutaController : ControllerBase
    {

        private LosPanchosContext context;

        public RutaController(LosPanchosContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //public  IEnumerable<Ruta> obtenerRutas() => context.Rutas.ToList();

        public async Task<IEnumerable<Ruta>> obtenerRutas()
        {
            return await context.rutas.ToListAsync();
        }
    }
}

