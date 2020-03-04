using System;

namespace Week5Decorator.Models
{
    public class Parent
    {
        public int id { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
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
