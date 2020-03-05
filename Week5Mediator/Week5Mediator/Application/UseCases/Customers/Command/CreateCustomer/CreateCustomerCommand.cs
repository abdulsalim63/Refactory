using System;
using MediatR;
using Week5Mediator.Application.UseCases.Customers.Models;

namespace Week5Mediator.Application.UseCases.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandDto>
    {
        public CustomerAttributes data { get; set; }
    }

    public class CustomerAttributes
    {
        public CustomerData attributes { get; set; }
    }
}
