using System;
namespace CustomerAndCustomerCard.Domain.Entities
{
    public class CustomerCard : Parent
    {
        public string name_on_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }

        public int customer_id { get; set; }
        public Customer Customer { get; set; }
    }
}
