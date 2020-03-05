using System;
using MediatR;
using Week5Mediator.Application.UseCases.CustomerCards.Models;

namespace Week5Mediator.Application.UseCases.CustomerCards.Command.DeleteCustomerCard
{
    public class DeleteCustomerCardCommand : IRequest<DeleteCustomerCardCommandDto>
    {
        public int id { get; set; }
    }
}
