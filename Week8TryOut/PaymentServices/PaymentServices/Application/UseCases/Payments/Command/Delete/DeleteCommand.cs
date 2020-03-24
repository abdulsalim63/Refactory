using System;
using MediatR;
using PaymentServices.Application.Models;

namespace PaymentServices.Application.UseCases.Payments //.Command.Delete
{
    public class DeletePaymentCommand : IRequest<BaseDto<Payment_Output>>
    {
        public int id { get; set; }
    }
}
