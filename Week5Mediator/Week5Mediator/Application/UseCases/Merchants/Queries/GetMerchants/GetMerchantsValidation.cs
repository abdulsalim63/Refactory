using System;
using FluentValidation;
using Week5Mediator.Application.UseCases.Merchants.Models;

namespace Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchants
{
    public class GetMerchantsValidation : AbstractValidator<GetMerchantsQuery>
    {
        public GetMerchantsValidation()
        {
        }
    }
}
