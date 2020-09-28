using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaugamaCorp.Server.Data;
using LaugamaCorp.Server.Helpers;
using LaugamaCorp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaugamaCorp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuplidoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuplidoresController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("lista")]
        public async Task<ActionResult<List<Suplidor>>> Get()
        {
            return await _context.Suplidores.OrderBy(x => x.Nombre).ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<List<Suplidor>>> GetAsync([FromQuery] PaginationModel pagination, [FromQuery] string nombre)
        {
            var queryable = _context.Suplidores.AsQueryable();
            if (!string.IsNullOrEmpty(nombre))
            {
                queryable = queryable.Where(x => x.Nombre.Contains(nombre));
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, pagination.CantidadAMostrar);
            return await queryable.Paginar(pagination).ToListAsync();

        }

        [HttpGet("{id}", Name = "obtenerSuplidor")]
        public async Task<ActionResult<Suplidor>> GetAsync(int id)
        {
            return await _context.Suplidores.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Suplidor suplidor)
        {
            _context.Add(suplidor);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerSuplidor", new { id = suplidor.Id }, suplidor);
        }
        [HttpPut]
        public async Task<ActionResult> PutAsync(Suplidor suplidor)
        {
            _context.Entry(suplidor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int ID)
        {
            var suplidor = new Suplidor { Id = ID };
            _context.Remove(suplidor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
