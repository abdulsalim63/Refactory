using System;
using Week5Mediator.Application.UseCases.Products.Models;
using Week5Mediator.Application.Models.Query;

namespace Week5Mediator.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductDto : BaseDto
    {
        public ProductData Data { get; set; }
    }
}
