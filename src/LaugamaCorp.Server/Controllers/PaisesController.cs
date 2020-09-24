
using LaugamaCorp.Server.Data;
using LaugamaCorp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaugamaCorp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pais>>> Get()
        {
            return await _context.Pais.OrderBy(x => x.Nombre).ToListAsync();
        }

        [HttpGet("{paisId}/estados")]
        public async Task<List<Estado>> GetEstados(int paisId)
        {
            return await _context.Estado.Where(x => x.PaisId == paisId)
                .OrderBy(x => x.Nombre).ToListAsync();
        }
    }
}