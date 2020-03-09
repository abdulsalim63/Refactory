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
    public class GetMerchantHandler : IRequestHandler<GetMerchantQuery, BaseDto<MerchantInput>>
    {
        private readonly ProjectContext _context;

        public GetMerchantHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<MerchantInput>> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.merchants.FindAsync(request.id);
            if (result == null)
            {
                return new BaseDto<MerchantInput>
                {
                    Message = "Failed retrieve merchant data",
                    Status = false,
                    Data = null
                };
            }
            else
            {
                return new BaseDto<MerchantInput>
                {
                    Message = "Success retrieve merchant data",
                    Status = true,
                    Data = new MerchantInput
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
}
