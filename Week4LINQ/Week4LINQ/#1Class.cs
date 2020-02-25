using System;
using System.Collections.Generic;

namespace Week4LINQ
{
    public class user1
    {
        public int id { get; set; }
        public string username { get; set; }
        public profile profile { get; set; }
        public List<article> articles { get; set; }
    }

    public class profile
    {
        public string full_name { get; set; }
        public string birthday { get; set; }
        public List<string> phones { get; set; }
    }

    public class article
    {
        public int id { get; set; }
        public string title { get; set; }
        public string published_at { get; set; }
    }
}
