using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaugamaCorp.Server.Data;
using LaugamaCorp.Server.Helpers;
using LaugamaCorp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaugamaCorp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("lista")]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await _context.Clientes.OrderBy(x => x.Nombre).ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAsync([FromQuery] PaginationModel pagination, [FromQuery] string nombre)
        {
            var queryable = _context.Clientes.AsQueryable();
            if (!string.IsNullOrEmpty(nombre))
            {
                queryable = queryable.Where(x => x.Nombre.Contains(nombre));
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, pagination.CantidadAMostrar);
            return await queryable.Paginar(pagination).ToListAsync();

        }
      
        [HttpGet("{id}", Name ="obtenerCliente")]
        public async Task<ActionResult<Cliente>> GetAsync(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cliente cliente)
        {
            if(cliente.TipoCliente != "Persona física")
            {
                cliente.TipoIdentificacion = "RNC";
            }
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerCliente", new { id = cliente.Id }, cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        public async Task<ActionResult> PutAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int ID)
        {
            var cliente = new Cliente { Id = ID };
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
