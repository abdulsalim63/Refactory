using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Notification.Application.UseCases.Notifications//.Models
{
    public class NotifInput
    {
        public string title { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public List<Target> targets { get; set; }
    }

    public class Target
    {
        [Required]
        public int id { get; set; }
        [Required]
        [EmailAddress]
        public string email_destination { get; set; }
    }
}
