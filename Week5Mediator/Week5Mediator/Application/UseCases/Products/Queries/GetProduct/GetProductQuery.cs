using System;
using MediatR;

namespace Week5Mediator.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public int id { get; set; }
    }
}
