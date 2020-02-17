using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Week3WebApi.Model;

namespace Week3WebApi.Controllers
{
    [ApiController]
    [Route("[contact]")]
    public class ContactController : ControllerBase
    {
        private static readonly List<Contact> contacts = new List<Contact>()
        {
            new Contact { Id = 1, Username = "fas11", Password = "1234", Email = "fas@hotmail.com", FullName = "Fast Forward"},
            new Contact { Id = 2, Username = "fas11", Password = "1234", Email = "fas@hotmail.com", FullName = "Fast Forward"},
            new Contact { Id = 3, Username = "fas11", Password = "1234", Email = "fas@hotmail.com", FullName = "Fast Forward"},
            new Contact { Id = 4, Username = "fas11", Password = "1234", Email = "fas@hotmail.com", FullName = "Fast Forward"},
        };

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "succes", message = "succes get data", data = contacts });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { status = "succes", message = "success get data", data = contacts.Find(x => x.Id == id) });
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact user)
        {
            contacts.Add(user);
            return Ok(new { status = "succes", message = "success add data", data = user });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            contacts.RemoveAll(x => x.Id == id);
            return Ok(new { status = "success", message = "success delete data" });
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(Contact user)
        {
            contacts.RemoveAll(x => x.Id == user.Id);
            contacts.Add(user);
            return Ok(new { status = "success", message = "success patch data", data = user });
        }

    }
}
