using AutoMapper;
using AutoMapper.QueryableExtensions;
using IntroduccionAEFCore.DTOs;
using IntroduccionAEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionAEFCore.Controllers
{
    // aqui decimos que todas las rutas va a tener como raiz: api/actores
    [ApiController]
    [Route("api/actores")]
    public class ActoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actores.OrderByDescending(a => a.FechaNacimiento).ToListAsync();
        }

        // la ruta: api/actores/nombres
        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string nombre)
        {
            // Versión 1
            return await context.Actores
                .Where(a => a.Nombre == nombre)
                .OrderBy(a => a.Nombre)
                    .ThenByDescending(a => a.FechaNacimiento)
                .ToListAsync();
        }

        [HttpGet("nombre/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetV2(string nombre)
        {
            // Versión 2: Contiene
            return await context.Actores.Where(a => a.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime inicio, 
            DateTime fin)
        {
            return await context.Actores
                .Where(a => a.FechaNacimiento >= inicio && a.FechaNacimiento <= fin)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(a => a.Id == id);

            if (actor is null)
            {
                return NotFound();
            }

            return actor;
        }

        // para traer solo algunas columnas se usa el Select
        [HttpGet("idynombre")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> Getidynombre()
        {
            // Para proyectar a un tipo anonimo
            //var actores = await context.Actores.Select( a => new { Id = a.Id, Nombre = a.Nombre }).ToListAsync();
            // Para proyectar a una clase se usa un DTO response
            return await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
