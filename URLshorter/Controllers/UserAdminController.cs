using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLshorter.Data.Rol;
using URLshorter.Entities;
using URLshorter.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URLshorter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAdminController : Controller
    {
        private readonly URLshorterContext _context;

        public UserAdminController(URLshorterContext context)
        {
            _context = context;
        }

        
        [HttpPost("crear-usuario")]
        public async Task<IActionResult> CreateUser(UserForCreationsDTO user)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User()
                {
                    Email = user.Email,
                    Pass = user.Pass,
                    Rol = Rol.User


                };
                _context.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok(newUser);
            }
            return BadRequest(ModelState);

        }
        [HttpGet("listar-usuarios")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}

