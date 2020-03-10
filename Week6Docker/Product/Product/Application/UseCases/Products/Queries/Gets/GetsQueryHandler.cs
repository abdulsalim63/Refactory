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
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, BaseDto<IList<ProductInput>>>
    {
        private readonly ProjectContext _context;

        public GetProductsHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<IList<ProductInput>>> Handle(GetProductsQuery request, CancellationToken cancellationToken) =>
            new BaseDto<IList<ProductInput>>
            {
                Message = "Success retrieve Product datas",
                Status = true,
                Data = await _context.products.OrderBy(x => x.id).Select(result => new ProductInput
                {
                    merchant_id = result.merchant_id,
                    name = result.name,
                    price = result.price
                }).ToListAsync()
            };
    }
}
