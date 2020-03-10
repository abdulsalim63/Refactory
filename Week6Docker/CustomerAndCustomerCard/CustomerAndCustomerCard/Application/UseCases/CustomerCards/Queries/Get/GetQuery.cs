using System;
using CustomerAndCustomerCard.Application.Models.Query;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Queries.Get
{
    public class GetCustomerCardQuery : IRequest<BaseDto<CustomerCardInput>>
    {
        public int id { get; set; }
    }
}
