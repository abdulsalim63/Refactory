using System;
using Week5Mediator.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Week5Mediator.Application.UseCases.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandDto>
    {
        private readonly IBlogContext _context;

        public CreateCustomerCommandHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerCommandDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var customer = new Domain.Models.Customer
            {
                full_name = input.full_name,
                username = input.username,
                birthdate = input.birthdate,
                password = input.password,
                gender = input.gender,
                email = input.email,
                phone_number = input.phone_number
            };

            //_context.customers.Add(customer);
            //await _context.SaveChangesAsync(cancellationToken);

            return new CreateCustomerCommandDto
            {
                Message = "Success add customer data",
                Success = true,
                Data = customer
            };
        }
    }
}
