using System;

namespace Product.Application.UseCases.Products //.Models
{
    public class ProductInput
    {
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}
