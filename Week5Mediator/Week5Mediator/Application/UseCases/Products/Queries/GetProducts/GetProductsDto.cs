using System;
using Week5Mediator.Application.UseCases.Products.Models;
using Week5Mediator.Application.Models.Query;
using System.Collections.Generic;

namespace Week5Mediator.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsDto : BaseDto
    {
        public IList<ProductData> Data { get; set; }
    }
}
