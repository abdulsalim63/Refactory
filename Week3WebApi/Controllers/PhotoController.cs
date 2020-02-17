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
    [Route("[photo]")]
    public class PhotoController : ControllerBase
    {
        private static readonly List<Photo> Photos = new List<Photo>()
        {
            new Photo { Id = 1, Caption = "Booyah", Url = "9gag.com", Contact_id = 1 },
            new Photo { Id = 2, Caption = "Climate Change", Url = "9gag.com", Contact_id = 2 },
            new Photo { Id = 3, Caption = "Not a Challenge", Url = "9gag.com", Contact_id = 2 },
            new Photo { Id = 4, Caption = "Bs", Url = "9gag.com", Contact_id = 1 },
            new Photo { Id = 5, Caption = "Needy", Url = "9gag.com", Contact_id = 1 }
        };

        private readonly ILogger<PhotoController> _logger;

        public PhotoController(ILogger<PhotoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "succes", message = "succes get data", data = Photos });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { status = "succes", message = "success get data", data = Photos.Find(x => x.Id == id) });
        }

        [HttpPost]
        public IActionResult ContactAdd(Photo user)
        {
            Photos.Add(user);
            return Ok(new { status = "succes", message = "success add data", data = user });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            Photos.RemoveAll(x => x.Id == id);
            return Ok(new { status = "success", message = "success delete data" });
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(Photo user)
        {
            Photos.RemoveAll(x => x.Id == user.Id);
            Photos.Add(user);
            return Ok(new { status = "success", message = "success patch data", data = user });
        }
    }
}
