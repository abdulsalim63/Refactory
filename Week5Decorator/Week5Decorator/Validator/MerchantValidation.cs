using System;
using FluentValidation;
using Week5Decorator.Models;

namespace Week5Decorator.Validator
{
    public class MerchantValidation : AbstractValidator<Request<Merchant>>
    {
        public MerchantValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.data.attributes.rating).InclusiveBetween(1, 5).WithMessage("rating must bettween 1-5");
        }
    }
}
