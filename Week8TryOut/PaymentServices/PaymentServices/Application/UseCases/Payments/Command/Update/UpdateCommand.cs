using System;
using MediatR;
using PaymentServices.Application.Models;

namespace PaymentServices.Application.UseCases.Payments //.Command.Update
{
    public class UpdatePaymentCommand : CreatePaymentCommand
    {
        public int id { get; set; }
    }
}
