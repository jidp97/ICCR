using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LaugamaCorp.Server.Data;
using LaugamaCorp.Server.Helpers;
using LaugamaCorp.Shared.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaugamaCorp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public InventoryController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        } 

        public async Task<ActionResult<List<Producto>>> GetAsync([FromQuery] PaginationModel pagination, [FromQuery] string nombre)
        {
            var queryable = _context.Inventory.AsQueryable();
         
            if (!string.IsNullOrEmpty(nombre))
            {
               
                if(CodigoExists(nombre))
                {
                    queryable = queryable.Where(x => x.Codigo.Contains(nombre));
                }
                else {
                    queryable = queryable.Where(x => x.Articulo.Contains(nombre));
                }
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, pagination.CantidadAMostrar);
            return await queryable.Include(x=> x.Categoria)
                .Include(x=> x.Suplidor).Paginar(pagination).ToListAsync();

        }
        [HttpGet("{id}", Name = "obtenerArticulo")]
        public async Task<ActionResult<Producto>> GetAsync(int id)
        {
            return await _context.Inventory.Include(x=> x.Categoria).FirstOrDefaultAsync(x => x.id == id);
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync(Producto articulo)
        {
           

           var lastId = await _context.Inventory
                .Where(x=> x.CategoriaId == articulo.CategoriaId)
                .OrderByDescending(x => x.id)
                .FirstOrDefaultAsync(x => x.id >=0);
           var newId = 0;

           if(lastId != null)
            {
                var idSinLetras = lastId.Codigo;
                if (lastId.Codigo.Length > 4)
                {
                    idSinLetras = idSinLetras.Substring(3, 4);
                }
                 newId = Int32.Parse(idSinLetras) + 1;
            }
            else
            {
                newId = 1;
            }                                         

            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == articulo.CategoriaId);
            
            char[] RemoverPalabras = { 'P', 'i', 'e', 'z', 'a', 's', ' ', 'd' };
            var abreviada = "";
          
            switch (categoria.Nombre)
            {
                case "Flores permanentes":
                    abreviada = "FLR";
                    break;

                case "Cristaleria":
                    abreviada = "CRT";
                    break;

                case "Cerámicas":
                    abreviada = "CRM";
                    break;
                case "Platos":
                    abreviada = "PLT";
                    break;
                case "Mesas":
                    abreviada = "MSA";
                    break;

                default:
                    var modificada = categoria.Nombre.TrimStart(RemoverPalabras);
                    abreviada = modificada.Substring(0, 3).ToUpper();
                    Regex ReemplazarAcentos = new Regex("[Á|á]", RegexOptions.Compiled);
                    abreviada = ReemplazarAcentos.Replace(abreviada, "A");
                    break;
            }
            
            var numero = String.Format("{0:0000}", newId);
            var codigo = abreviada + numero;
            articulo.Codigo = codigo;
            if (articulo.PrecioReposicion <= 0)
            {
                articulo.PrecioReposicion = articulo.Precio * (decimal)3.00;
            }
            if (articulo.PrecioAlquiler <= 0)
            {
                articulo.PrecioAlquiler = articulo.Precio / (decimal)3.00;
            }
            if(articulo.SuplidorId == 0)
            {
                articulo.SuplidorId = 4;
            }
          
            articulo.FechaRegistro = DateTime.Now;            
            _context.Add(articulo);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerArticulo", new { id = articulo.id }, articulo);

        }
        [HttpPut]
        public async Task<ActionResult> PutAsync(Producto articulo)
        {
            _context.Entry(articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int ID)
        {
            var articulo = new Producto { id = ID };
            _context.Remove(articulo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CodigoExists(string codigo)
        {
            return _context.Inventory.Any(e => e.Codigo == codigo);
        }
    }
}
