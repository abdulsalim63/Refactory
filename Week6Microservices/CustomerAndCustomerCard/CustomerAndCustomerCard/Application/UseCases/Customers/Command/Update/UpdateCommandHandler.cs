using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Infrastructure;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.Customers //.Command.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, BaseDto<CustomerInput>>
    {
        private readonly ProjectContext _context;

        public UpdateCustomerCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerInput>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.customers.FindAsync(request.id);
                var input = request.data.attributes;

                result.full_name = input.full_name;
                result.username = input.username;
                result.email = input.email;
                result.password = input.password;
                result.gender = input.gender;
                result.phone_number = input.phone_number;
                result.birthdate = input.birthdate;
                result.updated_at = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;

                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<CustomerInput>
                {
                    Message = "Success update customer data",
                    Status = true,
                    Data = input
                };
            }
            catch (Exception)
            {
                return new BaseDto<CustomerInput>
                {
                    Message = "Failed update customer data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
