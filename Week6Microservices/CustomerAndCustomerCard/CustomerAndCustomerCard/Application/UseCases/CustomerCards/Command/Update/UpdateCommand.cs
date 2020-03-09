using System;
using CustomerAndCustomerCard.Application.Models.Query;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Command.Update
{
    public class UpdateCustomerCardCommand : BaseRequest<CustomerCardInput>
    {
        public int id { get; set; }
    }
}
