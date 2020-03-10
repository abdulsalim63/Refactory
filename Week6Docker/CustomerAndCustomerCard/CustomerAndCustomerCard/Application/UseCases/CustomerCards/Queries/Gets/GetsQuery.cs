using System;
using System.Collections.Generic;
using CustomerAndCustomerCard.Application.Models.Query;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Queries.Gets
{
    public class GetCustomerCardsQuery : IRequest<BaseDto<IList<CustomerCardInput>>>
    {
    }
}
