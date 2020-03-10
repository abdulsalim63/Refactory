using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Infrastructure;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.Customers //.Command.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, BaseDto<CustomerInput>>
    {
        private readonly ProjectContext _context;

        public DeleteCustomerCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerInput>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.customers.FindAsync(request.id);

                _context.customers.Remove(result);
                await _context.SaveChangesAsync();

                return new BaseDto<CustomerInput>
                {
                    Message = "Success delete customer data",
                    Status = true,
                    Data = new CustomerInput
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
            catch (Exception)
            {
                return new BaseDto<CustomerInput>
                {
                    Message = "Failed delete customer data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
