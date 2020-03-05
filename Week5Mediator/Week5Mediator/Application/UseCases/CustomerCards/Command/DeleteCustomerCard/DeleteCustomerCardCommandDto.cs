using System;
using Week5Mediator.Application.Models.Query;
using Week5Mediator.Domain.Models;

namespace Week5Mediator.Application.UseCases.CustomerCards.Command.DeleteCustomerCard
{
    public class CreateCustomerCardCommandDto : BaseDto
    {
        public CustomerCard Data { get; set; }
    }
}
