using System;
using Week5Mediator.Application.UseCases.CustomerCards.Models;
using Week5Mediator.Application.Models.Query;
using System.Collections.Generic;

namespace Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCards
{
    public class GetCustomerCardsDto : BaseDto
    {
        public IList<CustomerCardsData> Data { get; set; }
    }
}
