using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLshorter.Entities;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URLshorter.Controllers
{
    
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly URLshorterContext _context;
        public CategoryController(URLshorterContext context)
        {
            _context = context;
        }


        [HttpGet("mostrar-categorias")]
        public async Task<IActionResult> ShowCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost("crear-nueva-categoria")]
        public async Task<IActionResult> CreateNewCategory([FromBody] Category category)
        {
            if (ModelState.IsValid) 
            {
                // Agrega la categoría a la base de datos.
                _context.Categories.Add(category); 
                await _context.SaveChangesAsync(); 

                return Ok(category); 
            }
            else
            {
                return BadRequest(ModelState); 
            }
        }
        
    }
    
}

