using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Application.Models.Query;
using Product.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Product.Application.UseCases.Products //.Queries.Gets
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, BaseDto<ProductInput>>
    {
        private readonly ProjectContext _context;

        public GetProductHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<ProductInput>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.products.FindAsync(request.id);
            if (result == null)
            {
                return new BaseDto<ProductInput>
                {
                    Message = "Failed retrieve Product data",
                    Status = false,
                    Data = null
                };
            }
            else
            {
                return new BaseDto<ProductInput>
                {
                    Message = "Success retrieve Product data",
                    Status = true,
                    Data = new ProductInput
                    {
                        merchant_id = result.merchant_id,
                        name = result.name,
                        price = result.price
                    }
                };
            }
        }
    }
}
