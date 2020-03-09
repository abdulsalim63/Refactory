using System;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.CustomerCards //.Command.Delete
{
    public class DeleteCustomerCardCommand : IRequest<BaseDto<CustomerCardInput>>
    {
        public int id { get; set; }
    }
}
