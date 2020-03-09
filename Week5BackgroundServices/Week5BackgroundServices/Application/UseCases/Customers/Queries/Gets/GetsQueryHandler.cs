using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Week5BackgroundServices.Application.UseCases.Customers //.Queries.Gets
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, BaseDto<IList<CustomerInput>>>
    {
        private readonly ProjectContext _context;

        public GetCustomersHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<IList<CustomerInput>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken) =>
            new BaseDto<IList<CustomerInput>>
            {
                Message = "Success retrieve customer datas",
                Status = true,
                Data = await _context.customers.OrderBy(x => x.id).Select(result => new CustomerInput
                {
                    full_name = result.full_name,
                    username = result.username,
                    password = result.password,
                    email = result.email,
                    birthdate = result.birthdate,
                    gender = result.gender,
                    phone_number = result.phone_number
                }).ToListAsync()
            };
    }
}
