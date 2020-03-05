using System;
namespace Week5Mediator.Application.Models.Query
{
    public abstract class BaseDto
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
