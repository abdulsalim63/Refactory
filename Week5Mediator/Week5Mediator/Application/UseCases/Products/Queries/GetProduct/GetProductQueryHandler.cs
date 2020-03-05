using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.Products.Models;

namespace Week5Mediator.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly IBlogContext _context;

        public GetProductQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.products.FirstOrDefaultAsync(x => x.id == request.id);

            return new GetProductDto
            {
                Message = "Success retrieve product data",
                Success = true,
                Data = new ProductData
                {
                    name = result.name,
                    price = result.price
                }
            };
        }
    }
}
