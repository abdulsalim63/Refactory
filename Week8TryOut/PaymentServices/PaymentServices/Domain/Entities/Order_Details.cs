using System;
namespace PaymentServices.Domain.Entities
{
    public class Order_Details : Parent
    {
        public int product_id { get; set; }
        public int order_id { get; set; }
        public int count { get; set; }
        public int price { get; set; }
    }
}
