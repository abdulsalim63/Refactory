using System;
namespace PaymentServices.Domain.Entities
{
    public class Payment : Parent
    {
        public int order_id { get; set; }
        public string transaction_id { get; set; }
        public string payment_type { get; set; }
        public string gross_amount { get; set; }
        public string transaction_time { get; set; }
        public string transaction_status { get; set; }
    }
}
