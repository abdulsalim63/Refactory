using System;
using System.Collections.Generic;

namespace Day4Json
{
    public class user
    {
        public int id { get; set; }
        public string username { get; set; }
        public profile profile { get; set; }
        public article[] articles { get; set; }
    }

    public class profile
    {
        public string full_name { get; set; }
        public string birthday { get; set; }
        public string[] phones { get; set; }
    }

    public class article
    {
        public int id { get; set; }
        public string title { get; set; }
        public string published_at { get; set; }
    }
}
