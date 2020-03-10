using System;
using System.Collections.Generic;
using MediatR;
using Product.Application.Models.Query;

namespace Product.Application.UseCases.Products //.Queries.Gets
{
    public class GetProductsQuery : IRequest<BaseDto<IList<ProductInput>>>
    {
    }
}
