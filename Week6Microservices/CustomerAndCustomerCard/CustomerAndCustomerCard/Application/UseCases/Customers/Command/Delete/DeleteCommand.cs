using System;
using CustomerAndCustomerCard.Application.Models.Query;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.Customers //.Command.Delete
{
    public class DeleteCustomerCommand : IRequest<BaseDto<CustomerInput>>
    {
        public int id { get; set; }
    }
}
