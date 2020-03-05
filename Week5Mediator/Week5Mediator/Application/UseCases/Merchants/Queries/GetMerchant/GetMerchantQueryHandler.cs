using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.Merchants.Models;

namespace Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDto>
    {
        private readonly IBlogContext _context;

        public GetMerchantQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetMerchantDto> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.merchants.FirstOrDefaultAsync(x => x.id == request.id);

            return new GetMerchantDto
            {
                Message = "Success retrieve merchant data",
                Success = true,
                Data = new MerchantData
                {
                    name = result.name,
                    image = result.image,
                    address = result.address,
                    rating = result.rating
                }
            };
        }
    }
}
