using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;

namespace Week5BackgroundServices.Application.UseCases.Customers //.Command.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<BaseRequest<CustomerInput>, BaseDto<CustomerInput>>
    {
        private readonly ProjectContext _context;

        public CreateCustomerCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerInput>> Handle(BaseRequest<CustomerInput> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var customer = new Domain.Entities.Customer
            {
                full_name = input.full_name,
                username = input.username,
                birthdate = input.birthdate,
                password = input.password,
                gender = input.gender,
                email = input.email,
                phone_number = input.phone_number
            };

            _context.customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<CustomerInput>
            {
                Message = "Success add customer data",
                Status = true,
                Data = input
            };
        }
    }
}
