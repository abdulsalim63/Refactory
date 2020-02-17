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
    [Route("[comment]")]
    public class PhotoCommentController : ControllerBase
    {
        private static readonly List<PhotoComment> photoComments = new List<PhotoComment> ()
        {
            new PhotoComment { Id = 1, Content = "Booo..", Photo_id = 1, Contact_id = 1},
            new PhotoComment { Id = 2, Content = "Not Cool", Photo_id = 2, Contact_id = 1},
            new PhotoComment { Id = 3, Content = "Nerdd", Photo_id = 1, Contact_id = 2},
            new PhotoComment { Id = 4, Content = "Weeb", Photo_id = 3, Contact_id = 1}
        };

        private readonly ILogger<PhotoCommentController> _logger;

        public PhotoCommentController(ILogger<PhotoCommentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "succes", message = "succes get data", data = photoComments });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { status = "succes", message = "success get data", data = photoComments.Find(x => x.Id == id) });
        }

        [HttpPost]
        public IActionResult ContactAdd(PhotoComment user)
        {
            photoComments.Add(user);
            return Ok(new { status = "succes", message = "success add data", data = user });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            photoComments.RemoveAll(x => x.Id == id);
            return Ok(new { status = "success", message = "success delete data" });
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(PhotoComment user)
        {
            photoComments.RemoveAll(x => x.Id == user.Id);
            photoComments.Add(user);
            return Ok(new { status = "success", message = "success patch data", data = user });
        }
    }
}
