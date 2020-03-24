using System;
using System.Collections.Generic;

namespace Notification.Application.UseCases.Notifications //.Models
{
    public class NotifGet
    {
        public int total { get; set; }
        public int read_count { get; set; }
        public List<notificationsGet> notifications { get; set; }
        public List<Logs> notification_logs { get; set; }
    }

    public class notificationsGet
    {
        public int id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
    }

    public class Logs
    {
        public int notification_id { get; set; }
        public int from { get; set; }
        public Nullable<DateTime> read_at { get; set; }
        public int target { get; set; }
    }
}
