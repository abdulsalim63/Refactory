using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Infrastructure;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Command.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCardCommand, BaseDto<CustomerCardInput>>
    {
        private readonly ProjectContext _context;

        public DeleteCustomerCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerCardInput>> Handle(DeleteCustomerCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.customercards.FindAsync(request.id);

                _context.customercards.Remove(result);
                await _context.SaveChangesAsync();

                return new BaseDto<CustomerCardInput>
                {
                    Message = "Success delete customer card payment data",
                    Status = true,
                    Data = new CustomerCardInput
                    {
                        customer_id = result.customer_id,
                        name_on_card = result.name_on_card,
                        exp_month = result.exp_month,
                        exp_year = result.exp_year,
                        postal_code = result.postal_code,
                        credit_card_number = result.credit_card_number
                    }
                };
            }
            catch (Exception)
            {
                return new BaseDto<CustomerCardInput>
                {
                    Message = "Failed delete customer card payment data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
