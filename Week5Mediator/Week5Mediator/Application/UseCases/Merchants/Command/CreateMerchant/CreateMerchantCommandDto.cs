using System;
using Week5Mediator.Application.Models.Query;
using Week5Mediator.Domain.Models;

namespace Week5Mediator.Application.UseCases.Merchants.Command.CreateMerchant
{
    public class CreateMerchantCommandDto : BaseDto
    {
        public Merchant Data { get; set; }
    }
}
