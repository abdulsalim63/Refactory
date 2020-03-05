using System;
using MediatR;

namespace Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCard
{
    public class GetCustomerCardQuery : IRequest<GetCustomerCardDto>
    {
        public int id { get; set; }
    }
}
