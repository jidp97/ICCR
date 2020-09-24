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
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await _context.Categorias.OrderBy(x => x.Nombre).ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetAsync([FromQuery] PaginationModel pagination, [FromQuery] string nombre)
        {
            var queryable = _context.Categorias.AsQueryable();
            if (!string.IsNullOrEmpty(nombre))
            {
                queryable = queryable.Where(x => x.Nombre.Contains(nombre));
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, pagination.CantidadAMostrar);
            return await queryable.Paginar(pagination).ToListAsync();

        }

        [HttpGet("{id}", Name = "obtenerCategoria")]
        public async Task<ActionResult<Categoria>> GetAsync(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Categoria categoria)
        {           
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerCategoria", new { id = categoria.Id }, categoria);
        }
        [HttpPut]
        public async Task<ActionResult> PutAsync(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int ID)
        {
            var categoria = new Categoria { Id = ID };
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
