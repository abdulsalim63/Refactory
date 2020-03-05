using System;
using FluentValidation;

namespace Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCards
{
    public class GetCustomerCardsValidation : AbstractValidator<GetCustomerCardsQuery>
    {
        public GetCustomerCardsValidation()
        {
        }
    }
}
