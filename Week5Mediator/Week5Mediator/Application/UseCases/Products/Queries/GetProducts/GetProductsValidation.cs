using System;
using FluentValidation;
using Week5Mediator.Application.UseCases.Products.Models;

namespace Week5Mediator.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsValidation : AbstractValidator<GetProductsQuery>
    {
        public GetProductsValidation()
        {
        }
    }
}
