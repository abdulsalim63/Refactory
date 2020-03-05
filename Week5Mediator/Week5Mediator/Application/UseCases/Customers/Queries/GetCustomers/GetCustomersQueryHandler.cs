using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.Customers.Models;

namespace Week5Mediator.Application.UseCases.Customers.Queries.GetCustomers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
        private readonly IBlogContext _context;

        public GetCustomerQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.customers.ToListAsync();

            return new GetCustomersDto
            {
                Message = "Success retrieve customer data",
                Success = true,
                Data = result.Select(s => new CustomerData {
                    full_name = s.full_name,
                    username = s.username,
                    birthdate = s.birthdate,
                    password = s.password,
                    gender = s.gender,
                    email = s.email,
                    phone_number = s.phone_number
                }).ToList()
            };
        }
    }
}
