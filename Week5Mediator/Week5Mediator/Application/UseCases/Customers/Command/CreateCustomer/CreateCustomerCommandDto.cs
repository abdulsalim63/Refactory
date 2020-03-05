using System;
using Week5Mediator.Application.Models.Query;
using Week5Mediator.Domain.Models;

namespace Week5Mediator.Application.UseCases.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandDto : BaseDto
    {
        public Customer Data { get; set; }
    }
}
