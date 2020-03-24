using System;
using MediatR;
using PaymentServices.Application.Models;

namespace PaymentServices.Application.UseCases.Payments //.Queries.Get
{
    public class GetPaymentQuery : IRequest<BaseDto<Payment_Output>>
    {
        public int id { get; set; }
    }
}
