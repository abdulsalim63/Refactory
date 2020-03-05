using System;
using System.Collections.Generic;

namespace Week5Mediator.Domain.Models
{
    public class Customer : Parent
    {
        public string full_name { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public CustomerCard CustomerCard { get; set; }
    }

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

    public class Merchant : Parent
    {
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }

        public List<Product> Product { get; set; }
    }

    public class Product : Parent
    {
        public string name { get; set; }
        public int price { get; set; }

        public int merchant_id { get; set; }
        public Merchant Merchant { get; set; }
    }
}
