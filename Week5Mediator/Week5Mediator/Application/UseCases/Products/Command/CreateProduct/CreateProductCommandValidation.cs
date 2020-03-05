using System;
using FluentValidation;

namespace Week5Mediator.Application.UseCases.Products.Command.CreateProduct
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty")
                    .MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.data.attributes.price).NotEmpty().WithMessage("price can't be empty")
                    .GreaterThan(1000).WithMessage("price must be greater than 1000");
        }
    }
}
