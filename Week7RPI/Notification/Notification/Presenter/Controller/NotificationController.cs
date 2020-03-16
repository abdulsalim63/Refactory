using System;
using Microsoft.AspNetCore.Mvc;

namespace Notification.Presenter.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        public NotificationController()
        {
        }

        [HttpGet]
        public IActionResult Get(string include)
        {
            if (include==null)
            {
                return Ok(new { Message = "Just Fine" });
            }
            else
            {
                return Ok(new { Status = $"Work without {include} logs" });
            }
        }
    }
}
