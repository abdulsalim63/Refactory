using System;
using Week5Mediator.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Week5Mediator.Application.UseCases.Merchants.Command.CreateMerchant
{
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, CreateMerchantCommandDto>
    {
        private readonly IBlogContext _context;

        public CreateMerchantCommandHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<CreateMerchantCommandDto> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var merchant = new Domain.Models.Merchant
            {
                name = input.name,
                image = input.image,
                address = input.address,
                rating = input.rating
            };

            //_context.merchants.Add(merchant);
            //await _context.SaveChangesAsync(cancellationToken);

            return new CreateMerchantCommandDto
            {
                Message = "Success add merchant data",
                Success = true,
                Data = merchant
            };
        }
    }
}
