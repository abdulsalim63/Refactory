using System;
using System.Collections.Generic;
using MediatR;
using Merchant.Application.Models.Query;

namespace Merchant.Application.UseCases.Merchants //.Queries.Gets
{
    public class GetMerchantsQuery : IRequest<BaseDto<IList<MerchantInput>>>
    {
    }
}
