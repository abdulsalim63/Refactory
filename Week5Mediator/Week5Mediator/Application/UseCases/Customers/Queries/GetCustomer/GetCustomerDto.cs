using System;
using Week5Mediator.Application.UseCases.Customers.Models;
using Week5Mediator.Application.Models.Query;

namespace Week5Mediator.Application.UseCases.Customers.Queries.GetCustomer
{
    public class GetCustomerDto : BaseDto
    {
        public CustomerData Data { get; set; }
    }
}
