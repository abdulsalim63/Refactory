using System;
using MediatR;
using PaymentServices.Application.Models;

namespace PaymentServices.Application.UseCases.Payments //.Command.Create
{
    public class CreatePaymentCommand : BaseRequest<Payment_Input>, IRequest<BaseDto<Payment_Input>>
    {
    }
}
