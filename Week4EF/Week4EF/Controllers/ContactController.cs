using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Week4EF.Models;

namespace Week4EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ContactContext _context;

        public ContactController(ContactContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() =>  Ok(_context.contacts.OrderBy(x => x.id).ToList());

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                return Ok(_context.contacts.First(x => x.id == id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            _context.contacts.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletebyId(int id)
        {
            try
            {
                var result = _context.contacts.First(x => x.id == id);
                _context.contacts.Remove(result);
                _context.SaveChanges();
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]JsonPatchDocument<Contact> value)
        {
            try
            {
                var result = _context.contacts.First(x => x.id == id);
                value.ApplyTo(result);//result gets the values from the patch request
                _context.SaveChanges();

                return new ObjectResult(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
