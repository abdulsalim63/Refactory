using System;
using Week5Mediator.Application.Models.Query;
using Week5Mediator.Domain.Models;

namespace Week5Mediator.Application.UseCases.Products.Command.CreateProduct
{
    public class CreateProductCommandDto : BaseDto
    {
        public Product Data { get; set; }
    }
}
