using System;
using Week5Mediator.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Week5Mediator.Application.UseCases.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandDto>
    {
        private readonly IBlogContext _context;

        public CreateProductCommandHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<CreateProductCommandDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var product = new Domain.Models.Product
            {
                name = input.name,
                price = input.price
            };

            //_context.products.Add(product);
            //await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductCommandDto
            {
                Message = "Success add product data",
                Success = true,
                Data = product
            };
        }
    }
}
