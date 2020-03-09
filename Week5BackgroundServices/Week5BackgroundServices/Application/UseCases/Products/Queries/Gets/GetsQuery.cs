using System;
using System.Collections.Generic;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Products //.Queries.Gets
{
    public class GetProductsQuery : IRequest<BaseDto<IList<ProductInput>>>
    {
    }
}
