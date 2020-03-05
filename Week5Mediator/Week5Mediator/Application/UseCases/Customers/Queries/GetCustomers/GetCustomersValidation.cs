using System;
using FluentValidation;
using Week5Mediator.Application.UseCases.Customers.Models;

namespace Week5Mediator.Application.UseCases.Customers.Queries.GetCustomers
{
    public class GetCustomersValidation : AbstractValidator<GetCustomersQuery>
    {
        public GetCustomersValidation()
        {
        }
    }
}
