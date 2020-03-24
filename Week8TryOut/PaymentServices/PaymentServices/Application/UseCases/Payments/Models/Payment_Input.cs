using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentServices.Application.UseCases.Payments //.Models
{
    public class Payment_Input : Parent
    {
        [Required]
        public string bank { get; set; }
    }
}
