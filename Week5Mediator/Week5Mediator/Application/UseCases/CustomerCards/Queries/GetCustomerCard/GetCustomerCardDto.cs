using System;
using Week5Mediator.Application.UseCases.CustomerCards.Models;
using Week5Mediator.Application.Models.Query;

namespace Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCard
{
    public class GetCustomerCardDto : BaseDto
    {
        public CustomerCardsData Data { get; set; }
    }
}
