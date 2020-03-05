using System;
namespace Week5Mediator.Domain.Models
{
    public class Parent
    {
        public int id { get; set; }
        public long created_at { get; set; } = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;
        public long updated_at { get; set; } = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;
    }

    public class Request<T>
    {
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T attributes { get; set; }
    }
}
