using System;
using MediatR;

namespace Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchant
{
    public class GetMerchantQuery : IRequest<GetMerchantDto>
    {
        public int id { get; set; }
    }
}
