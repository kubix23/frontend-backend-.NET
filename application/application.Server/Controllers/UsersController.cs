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
    public class UsersController : ControllerBase
    {
        private readonly DB _context;

        public UsersController(DB context)
        {
            _context = context;
        }

        // GET: api/Users/test
        [HttpGet("{login}")]
        public async Task<ActionResult<User>> GetUser(string login)
        {
            var user = await _context.users.FindAsync(login);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PATCH: api/Users/test
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linklogin=2123754
        [HttpPatch("{login}")]
        public async Task<IActionResult> PatchUser(string login, User user)
        {
            if (!UserExists(login))
            {
                _context.users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(PatchUser), new { login = user.login }, user);
            }
            else
            {
                return Conflict();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{login}")]
        public async Task<IActionResult> DeleteUser(string login)
        {
            var user = await _context.users.FindAsync(login);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string login)
        {
            return _context.users.Any(e => e.login == login);
        }
    }
}
