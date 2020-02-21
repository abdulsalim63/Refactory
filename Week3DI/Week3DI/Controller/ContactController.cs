using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week3DI.Models;
using Week3DI;
using Microsoft.Extensions.Logging;

namespace Week3WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ContactController : ControllerBase
    {
        public IDatabase _database;

        public ContactController(IDatabase database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            var result = _database.Create(contact);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _database.Read();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _database.Read(id);
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = _database.Delete(id);
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(int id, Contact contact)
        {
            var result = _database.Update(id, contact);
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
