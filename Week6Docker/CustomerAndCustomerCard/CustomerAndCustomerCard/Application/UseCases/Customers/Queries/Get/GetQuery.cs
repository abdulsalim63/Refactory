using System;
using CustomerAndCustomerCard.Application.Models.Query;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.Customers //.Queries.Get
{
    public class GetCustomerQuery : IRequest<BaseDto<CustomerInput>>
    {
        public int id { get; set; }
    }
}
