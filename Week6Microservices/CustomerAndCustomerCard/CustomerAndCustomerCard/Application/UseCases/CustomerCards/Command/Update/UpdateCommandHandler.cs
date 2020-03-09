using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Infrastructure;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Command.Update
{
    public class UpdateCustomerCardCommandHandler : IRequestHandler<UpdateCustomerCardCommand, BaseDto<CustomerCardInput>>
    {
        private readonly ProjectContext _context;

        public UpdateCustomerCardCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerCardInput>> Handle(UpdateCustomerCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.customercards.FindAsync(request.id);
                var input = request.data.attributes;

                result.customer_id = input.customer_id;
                result.name_on_card = input.name_on_card;
                result.exp_month = input.exp_month;
                result.exp_year = input.exp_year;
                result.postal_code = input.postal_code;
                result.credit_card_number = input.credit_card_number;
                result.updated_at = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;

                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<CustomerCardInput>
                {
                    Message = "Success update customer card payment data",
                    Status = true,
                    Data = input
                };
            }
            catch (Exception)
            {
                return new BaseDto<CustomerCardInput>
                {
                    Message = "Failed update customer card payment data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
