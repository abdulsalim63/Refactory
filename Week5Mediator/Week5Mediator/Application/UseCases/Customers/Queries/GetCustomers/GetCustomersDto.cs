using System;
using Week5Mediator.Application.UseCases.Customers.Models;
using Week5Mediator.Application.Models.Query;
using System.Collections.Generic;

namespace Week5Mediator.Application.UseCases.Customers.Queries.GetCustomers
{
    public class GetCustomersDto : BaseDto
    {
        public IList<CustomerData> Data { get; set; }
    }
}
