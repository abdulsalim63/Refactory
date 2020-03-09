using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Week5BackgroundServices.Application.UseCases.Merchants //.Queries.Gets
{
    public class GetMerchantsHandler : IRequestHandler<GetMerchantsQuery, BaseDto<IList<MerchantInput>>>
    {
        private readonly ProjectContext _context;

        public GetMerchantsHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<IList<MerchantInput>>> Handle(GetMerchantsQuery request, CancellationToken cancellationToken) =>
            new BaseDto<IList<MerchantInput>>
            {
                Message = "Success retrieve merchant datas",
                Status = true,
                Data = await _context.merchants.OrderBy(x => x.id).Select(result => new MerchantInput
                {
                    name = result.name,
                    image = result.image,
                    address = result.address,
                    rating = result.rating
                }).ToListAsync()
            };
    }
}
