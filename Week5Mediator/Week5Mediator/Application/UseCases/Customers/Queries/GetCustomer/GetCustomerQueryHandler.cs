using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.Customers.Models;

namespace Week5Mediator.Application.UseCases.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
        private readonly IBlogContext _context;

        public GetCustomerQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.customers.FirstOrDefaultAsync(x => x.id == request.id);

            return new GetCustomerDto
            {
                Message = "Success retrieve customer data",
                Success = true,
                Data = new CustomerData
                {
                    full_name = result.full_name,
                    username = result.username,
                    birthdate = result.birthdate,
                    password = result.password,
                    gender = result.gender,
                    email = result.email,
                    phone_number = result.phone_number
                }
            };
        }
    }
}
