using System;
namespace User.Application.Models
{
    public class BaseDto<T>
    {
        public string message { get; set; }
        public bool success { get; set; }
        public T data { get; set; }
    }
}
