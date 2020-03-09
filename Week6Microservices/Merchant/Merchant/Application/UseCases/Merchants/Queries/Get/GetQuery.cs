using System;
using MediatR;
using Merchant.Application.Models.Query;

namespace Merchant.Application.UseCases.Merchants //.Queries.Get
{
    public class GetMerchantQuery : IRequest<BaseDto<MerchantInput>>
    {
        public int id { get; set; }
    }
}
