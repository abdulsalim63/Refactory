using System;
using System.Collections.Generic;

namespace Week5BackgroundServices.Domain.Entities
{
    public class Merchant : Parent
    {
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }

        public List<Product> Product { get; set; }
    }
}
