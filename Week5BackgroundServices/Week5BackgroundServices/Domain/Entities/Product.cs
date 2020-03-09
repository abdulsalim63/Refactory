using System;
namespace Week5BackgroundServices.Domain.Entities
{
    public class Product : Parent
    {
        public string name { get; set; }
        public int price { get; set; }

        public int merchant_id { get; set; }
        public Merchant Merchant { get; set; }
    }
}
