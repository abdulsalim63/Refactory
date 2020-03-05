using System;
using FluentValidation;

namespace Week5Mediator.Application.UseCases.Merchants.Command.CreateMerchant
{
    public class CreateMerchantCommandValidation : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantCommandValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.data.attributes.rating).InclusiveBetween(1, 5).WithMessage("rating must bettween 1-5");
        }
    }
}
