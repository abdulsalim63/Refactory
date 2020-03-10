using System;
using CustomerAndCustomerCard.Application.Models.Query;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Command.Delete
{
    public class DeleteCustomerCardCommand : IRequest<BaseDto<CustomerCardInput>>
    {
        public int id { get; set; }
    }
}
