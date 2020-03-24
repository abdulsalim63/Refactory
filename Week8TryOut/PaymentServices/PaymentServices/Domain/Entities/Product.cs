using System;
namespace PaymentServices.Domain.Entities
{
    public class Product : Parent
    {
        public string name { get; set; }
        public string price { get; set; }
    }
}
