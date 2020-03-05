using System;
using Week5Mediator.Application.UseCases.Merchants.Models;
using Week5Mediator.Application.Models.Query;
using System.Collections.Generic;

namespace Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchants
{
    public class GetMerchantsDto : BaseDto
    {
        public IList<MerchantData> Data { get; set; }
    }
}
