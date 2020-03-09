using System;
namespace Week5BackgroundServices.Application.Models.Query
{
    public class BaseDto<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
