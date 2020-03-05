using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.Products.Models;

namespace Week5Mediator.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsDto>
    {
        private readonly IBlogContext _context;

        public GetProductsQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetProductsDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var s = await _context.products.ToListAsync();

            return new GetProductsDto
            {
                Message = "Success retrieve product data",
                Success = true,
                Data = s.Select(s => new ProductData
                {
                    name = s.name,
                    price = s.price
                }).ToList()
            };
        }
    }
}
