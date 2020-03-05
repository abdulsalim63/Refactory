using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.Merchants.Models;

namespace Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchants
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDto>
    {
        private readonly IBlogContext _context;

        public GetMerchantQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetMerchantsDto> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var s = await _context.merchants.ToListAsync();

            return new GetMerchantsDto
            {
                Message = "Success retrieve merchant data",
                Success = true,
                Data = s.Select(s => new MerchantData
                {
                    name = s.name,
                    image = s.image,
                    address = s.address,
                    rating = s.rating
                }).ToList()
            };
        }
    }
}
