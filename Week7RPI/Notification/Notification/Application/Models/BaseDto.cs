using System;
namespace Notification.Application.Models
{
    public class BaseDto<T>
    {
        public string message { get; set; }
        public bool success { get; set; }
        public T data { get; set; }
    }
}
