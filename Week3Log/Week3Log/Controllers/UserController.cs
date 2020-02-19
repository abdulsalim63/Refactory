using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week3Log.Models;

namespace Week3Log.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserContext _context;

        private string intToString(int a)
        {
            var sequence = new string[] { "First", "Second", "Third", "Fourth", "Five" };
            return sequence[a];
        }

        public UserController(UserContext context)
        {
            _context = context;
            for (int i = 0; i < 5; i++)
            {
                if (_context.UserDb.Count() >= 5) { break; }
                _context.Add(new User { FirstName = "Alexander", LastName = $"The {intToString(i)}", NickName = $"{intToString(i)} Bandit" });
                _context.SaveChangesAsync();
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserDb()
        {
            return await _context.UserDb.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.UserDb.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.UserDb.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.UserDb.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserDb.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.UserDb.Any(e => e.Id == id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<User> value)
        {
            try
            {
                //nodes collection is an in memory list of nodes for this example
                var result = await _context.UserDb.FindAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                value.ApplyTo(result);//result gets the values from the patch request
                await _context.SaveChangesAsync();

                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
