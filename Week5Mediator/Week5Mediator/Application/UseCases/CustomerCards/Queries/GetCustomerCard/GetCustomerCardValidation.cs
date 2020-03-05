using System;
using FluentValidation;
using Week5Mediator.Application.UseCases.CustomerCards.Models;

namespace Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCard
{
    public class GetCustomerCardValidation : AbstractValidator<GetCustomerCardQuery>
    {
        public GetCustomerCardValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}
