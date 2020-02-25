using System;
using System.Collections.Generic;

namespace Week4LINQ
{
    public class user2
    {
        public string order_id { get; set; }
        public string created_at { get; set; }
        public customer customer { get; set; }
        public List<items> items { get; set; }
    }

    public class customer
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class items
    {
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public int price { get; set; }
    }
}
