
using LaugamaCorp.Shared.Models;
using LaugamaCorp.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaugamaCorp.Server.Helpers;
using System.Linq;

namespace LaugamaCorp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetAsync([FromQuery ]PaginationModel pagination, [FromQuery] string nombre)
        {
            var queryable = _context.Personas.AsQueryable();
            if (!string.IsNullOrEmpty(nombre))
            {
                queryable = queryable.Where(x => x.Nombre.Contains(nombre));
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, pagination.CantidadAMostrar);
            return await queryable.Include(x => x.Estado).Paginar(pagination).ToListAsync();
        }
        [HttpGet("{id}", Name = "obtenerPersona")]
        public async Task<ActionResult<Persona>> GetAsync(int id)
        {
            return await _context.Personas.Include(x => x.Estado).FirstOrDefaultAsync(x => x.ID == id);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerPersona", new { id = persona.ID }, persona);
            
        }
        [HttpPut]
        public async Task<ActionResult> PutAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var persona = new Persona { ID = id };
            _context.Remove(persona);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
