using System;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Customers //.Command.Delete
{
    public class DeleteCustomerCommand : IRequest<BaseDto<CustomerInput>>
    {
        public int id { get; set; }
    }
}
