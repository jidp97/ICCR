using LaugamaCorp.Client.Shared;
using LaugamaCorp.Server.Data;
using LaugamaCorp.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaugamaCorp.Server.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaugamaCorp.Shared.Models;
using LaugamaCorp.Server;
using System;

namespace BlazorPeliculas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsuariosController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Get([FromQuery] PaginationModel paginacion)
        {
            var queryable = context.Users.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadAMostrar);
            return await queryable.Paginar(paginacion)
                .Select(x => new UsuarioDTO { Email = x.Email, UserId = x.Id, FirtName = x.FirstName, LastName = x.LastName, Cargo = x.Cargo }).ToListAsync();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RolDTO>>> Get()
        {
            return await context.Roles
                .Select(x => new RolDTO { Nombre = x.Name, RoleId = x.Id }).ToListAsync();
        }
        [HttpGet("{UserId}/obtenerUsuario")]
        //[HttpGet("{UserId}", Name = "obtenerUsuario")]
        public async Task<ActionResult<UsuarioDTO>> GetAsync(string UserId)
        {
            return await context.Users
                .Select(x => new UsuarioDTO { Email = x.Email, UserId = x.Id, FirtName = x.FirstName, LastName = x.LastName, Cargo = x.Cargo })
                .FirstOrDefaultAsync(x => x.UserId == UserId);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(UsuarioDTO usuario)
        {

            var user = await userManager.FindByIdAsync(usuario.UserId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.FindByIdAsync(usuario.UserId)}'.");
            }

            var email = user.Email;
            if (usuario.Email != email)
            {
                var setEmailResult = await userManager.SetEmailAsync(user, usuario.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }
            //var phoneNumber = user.PhoneNumber;
            //if (usuario.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await userManager.SetPhoneNumberAsync(user, usuario.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
            //    }
            //}
            if (usuario.FirtName != user.FirstName)
            {
                user.FirstName = usuario.FirtName;
            }
            if (usuario.LastName != user.LastName)
            {
                user.LastName = usuario.LastName;
            }
            if (usuario.Cargo != user.Cargo)
            {
                user.Cargo = usuario.Cargo;
            }

            await userManager.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarUsuario(string id)
        {
            var usuario = new UsuarioDTO { UserId = id };
            var user = await userManager.FindByIdAsync(usuario.UserId);
            await userManager.DeleteAsync(user);
            return NoContent(); 
        }

        [HttpPost("asignarRol")]
        public async Task<ActionResult> AsignarRolUsuario(EditarRolDTO editarRolDTO)
        {
            var usuario = await userManager.FindByIdAsync(editarRolDTO.UserId);
            await userManager.AddToRoleAsync(usuario, editarRolDTO.RoleId);
            return NoContent();
        }

        [HttpPost("removerRol")]
        public async Task<ActionResult> RemoverUsuarioRol(EditarRolDTO editarRolDTO)
        {
            var usuario = await userManager.FindByIdAsync(editarRolDTO.UserId);
            await userManager.RemoveFromRoleAsync(usuario, editarRolDTO.RoleId);
            return NoContent();
        }
    }
}