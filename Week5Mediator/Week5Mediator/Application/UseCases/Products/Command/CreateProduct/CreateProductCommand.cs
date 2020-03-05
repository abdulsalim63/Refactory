using System;
using MediatR;
using Week5Mediator.Application.UseCases.Products.Models;

namespace Week5Mediator.Application.UseCases.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandDto>
    {
        public ProductAttributes data { get; set; }
    }

    public class ProductAttributes
    {
        public ProductData attributes { get; set; }
    }
}
