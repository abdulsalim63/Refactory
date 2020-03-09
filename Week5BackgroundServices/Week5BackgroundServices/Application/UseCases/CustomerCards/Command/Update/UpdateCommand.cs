using System;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.CustomerCards //.Command.Update
{
    public class UpdateCustomerCardCommand : BaseRequest<CustomerCardInput>
    {
        public int id { get; set; }
    }
}
