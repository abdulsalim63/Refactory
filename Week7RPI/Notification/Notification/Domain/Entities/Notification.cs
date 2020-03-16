using System;
namespace Notification.Domain.Entities
{
    public class Notification_Model : Parent
    {
        public string title { get; set; }
        public string message { get; set; }
    }
}
