using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentServices.Application.UseCases.Payments //.Models
{
    public class Parent
    {
        [Required]
        public string payment_type { get; set; }
        public long gross_amount { get; set; }
        public int order_id { get; set; }
    }
}
