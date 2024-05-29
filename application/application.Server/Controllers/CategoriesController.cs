using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using application.Server.Data.Database;
using application.Server.Data.Model;

namespace application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DB _context;

        public CategoriesController(DB context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Getcategory()
        {
            return await _context.category.Select(c => c).Where(ctx=> ctx.id < 4).ToListAsync();
        }

        // GET: api/Categories/1/subcategories
        [HttpGet("{id}/subcategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetSubcategory(int id)
        {
            return await _context.category.Select(c => c).Where(ctx => ctx.parentCategoryId == id).ToListAsync();
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.id)
            {
                return BadRequest();
            }

            var parentCategory = await _context.category.FindAsync(category.parentCategoryId);

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    if (parentCategory.name != "inny") return BadRequest();

                    _context.category.Add(category);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("PutCategory", new { id = category.id }, category);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.contacts.Any(e => e.id == id);
        }
    }
}
