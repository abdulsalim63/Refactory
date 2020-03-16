using System;
namespace Notification.Domain.Entities
{
    public class Notification_Model
    {
        public int id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public long created_at { get; set; }
        public long updatet_at { get; set; }
    }
}
