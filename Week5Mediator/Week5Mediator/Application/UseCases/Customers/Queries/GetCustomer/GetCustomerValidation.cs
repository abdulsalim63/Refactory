using System;
using FluentValidation;
using Week5Mediator.Application.UseCases.Customers.Models;

namespace Week5Mediator.Application.UseCases.Customers.Queries.GetCustomer
{
    public class GetCustomerValidation : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}
