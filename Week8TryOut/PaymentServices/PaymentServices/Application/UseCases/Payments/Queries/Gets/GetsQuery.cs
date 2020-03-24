using System;
using System.Collections.Generic;
using MediatR;
using PaymentServices.Application.Models;

namespace PaymentServices.Application.UseCases.Payments //.Queries.Gets
{
    public class GetPaymentsQuery : IRequest<BaseDto<List<Payment_Output>>>
    {
    }
}
