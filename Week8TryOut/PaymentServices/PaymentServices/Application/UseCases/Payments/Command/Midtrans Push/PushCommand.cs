using System;
using MediatR;
using PaymentServices.Application.Models;

namespace PaymentServices.Application.UseCases.Payments //.Command.MidtransPush
{
    public class PushMidtransCommand : IRequest<BaseDto<Payment_Output>>
    {
    }
}
