using System;
using MediatR;
using Week5Mediator.Application.UseCases.CustomerCards.Models;

namespace Week5Mediator.Application.UseCases.CustomerCards.Command.DeleteCustomerCard
{
    public class CreateCustomerCardCommand : IRequest<CreateCustomerCardCommandDto>
    {
        public CustomerCardAttributes data { get; set; }
    }

    public class CustomerCardAttributes
    {
        public CustomerCardsData attributes { get; set; }
    }
}
