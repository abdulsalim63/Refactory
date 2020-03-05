using System;
using FluentValidation;
using Week5Mediator.Application.UseCases.Merchants.Models;

namespace Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchant
{
    public class GetMerchantValidation : AbstractValidator<GetMerchantQuery>
    {
        public GetMerchantValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}
