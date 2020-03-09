using System;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Customers //.Command.Update
{
    public class UpdateCustomerCommand : BaseRequest<CustomerInput>
    {
        public int id { get; set; }
    }
}
