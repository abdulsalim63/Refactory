using System;
namespace Week5Mediator.Application.UseCases.CustomerCards.Models
{
    public class CustomerCardsData
    {
        public int customer_id { get; set; }
        public string name_on_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }
    }
}
