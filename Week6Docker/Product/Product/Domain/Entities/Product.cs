using System;
namespace Product.Domain.Entities
{
    public class ProductModel : Parent
    {
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}
