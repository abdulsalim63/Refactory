using System;
using System.Collections.Generic;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Merchants //.Queries.Gets
{
    public class GetMerchantQuery : IRequest<BaseDto<MerchantInput>>
    {
        public int id { get; set; }
    }
}
