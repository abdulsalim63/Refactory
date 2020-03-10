using System;
using CustomerAndCustomerCard.Application.Models.Query;

namespace CustomerAndCustomerCard.Application.UseCases.Customers //.Command.Update
{
    public class UpdateCustomerCommand : BaseRequest<CustomerInput>
    {
        public int id { get; set; }
    }
}
