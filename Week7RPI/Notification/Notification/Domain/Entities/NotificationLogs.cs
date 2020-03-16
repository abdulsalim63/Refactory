using System;
namespace Notification.Domain.Entities
{
    public class NotificationLogs : Parent
    {
        public int notification_id { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public int target { get; set; }
        public string email_destination { get; set; }
        public long read_at { get; set; }
    }
}
