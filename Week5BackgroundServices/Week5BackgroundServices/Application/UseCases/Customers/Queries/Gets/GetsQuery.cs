using System;
using System.Collections.Generic;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Customers //.Queries.Gets
{
    public class GetCustomersQuery : IRequest<BaseDto<IList<CustomerInput>>>
    {
    }
}
