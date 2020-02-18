using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week3WebAPI2.Models;

namespace Week3WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentController(CommentContext context)
        {
            _context = context;
            for (int i = 1; i <= 5; i++)
            {
                _context.CommentItems.Add(new Comment { Id = i, Content = "Boooo", Photo_id = 1, Contact_id = 1 });
                _context.SaveChangesAsync();
            }
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentItems()
        {
            return await _context.CommentItems.ToListAsync();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.CommentItems.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comment
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.CommentItems.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.CommentItems.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.CommentItems.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.CommentItems.Any(e => e.Id == id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<Comment> value)
        {
            try
            {
                //nodes collection is an in memory list of nodes for this example
                var result = await _context.CommentItems.FindAsync(id);
                if (result == null)
                {
                    return BadRequest();
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
