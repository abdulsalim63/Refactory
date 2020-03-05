using System;
using MediatR;

namespace Week5Mediator.Application.UseCases.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerDto>
    {
        public int id { get; set; }
    }
}
