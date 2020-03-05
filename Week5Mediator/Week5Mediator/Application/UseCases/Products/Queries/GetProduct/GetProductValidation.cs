using System;
using FluentValidation;
using Week5Mediator.Application.UseCases.Products.Models;

namespace Week5Mediator.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductValidation : AbstractValidator<GetProductQuery>
    {
        public GetProductValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}
