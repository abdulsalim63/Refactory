using System;
using System.Collections.Generic;

namespace Week4LINQ
{
    public class user3
    {
        public int inventory_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<string> tags { get; set; }
        public int purchased_at { get; set; }
        public placement placement { get; set; }
    }

    public class placement
    {
        public int room_id { get; set; }
        public string name { get; set; }
    }
}
