using System;
using Merchant.Application.Models.Query;
using FluentValidation;

namespace Merchant.Application.UseCases.Merchants //.Command.Create
{
    public class CreateMerchantCommandValidation : AbstractValidator<BaseRequest<MerchantInput>>
    {
        public CreateMerchantCommandValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.data.attributes.rating).InclusiveBetween(1, 5).WithMessage("rating must bettween 1-5");
        }
    }
}
