using System;
using System.Collections.Generic;
using CustomerAndCustomerCard.Application.Models.Query;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.Customers //.Queries.Gets
{
    public class GetCustomersQuery : IRequest<BaseDto<IList<CustomerInput>>>
    {
    }
}
