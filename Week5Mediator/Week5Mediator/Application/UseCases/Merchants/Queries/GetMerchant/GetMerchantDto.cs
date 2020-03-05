using System;
using Week5Mediator.Application.UseCases.Merchants.Models;
using Week5Mediator.Application.Models.Query;

namespace Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchant
{
    public class GetMerchantDto : BaseDto
    {
        public MerchantData Data { get; set; }
    }
}
