using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Week3WebAPI2.Models;
using Newtonsoft.Json;

namespace Week3WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly PhotoContext _context;

        public PhotoController(PhotoContext context)
        {
            _context = context;
            for (int i=1;i<=5;i++)
            {
                _context.PhotoItems.Add(new Photo { Id = i, Caption = $"Round {i}", Url = $"oracle.com/{i}", Contact_id = (i % 2 == 0) ? 1 : 2 });
                _context.SaveChangesAsync();
            }
        }

        // GET: api/Photo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhotoItems()
        {
            return await _context.PhotoItems.ToListAsync();
        }

        // GET: api/Photo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetPhoto(int id)
        {
            var photo = await _context.PhotoItems.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/Photo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(int id, Photo photo)
        {
            if (id != photo.Id)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        // POST: api/Photo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        {
            _context.PhotoItems.Add(photo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoto", new { id = photo.Id }, photo);
        }

        // DELETE: api/Photo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Photo>> DeletePhoto(int id)
        {
            var photo = await _context.PhotoItems.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.PhotoItems.Remove(photo);
            await _context.SaveChangesAsync();

            return photo;
        }

        private bool PhotoExists(int id)
        {
            return _context.PhotoItems.Any(e => e.Id == id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<Photo> value)
        {
            try
            {
                //nodes collection is an in memory list of nodes for this example
                var result = await _context.PhotoItems.FindAsync(id);
                if (result == null)
                {
                    return BadRequest();
                }
                value.ApplyTo(await _context.PhotoItems.FindAsync(id));//result gets the values from the patch request
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
