using System;
using System.Collections.Generic;

namespace Notification.Application.UseCases.Notifications //.Models
{
    public class NotifUpdate
    {
        public DateTime read_at { get; set; }
        public List<UpdateTarget> target { get; set; }
    }

    public class UpdateTarget
    {
        public int id { get; set; }
    }
}
