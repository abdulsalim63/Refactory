using System;
namespace PaymentServices.Application.UseCases.Payments //.Models
{
    public class Payment_Output : Parent
    {
        public string transaction_id { get; set; }
        public string transaction_time { get; set; }
        public string transaction_status { get; set; }
    }
}
