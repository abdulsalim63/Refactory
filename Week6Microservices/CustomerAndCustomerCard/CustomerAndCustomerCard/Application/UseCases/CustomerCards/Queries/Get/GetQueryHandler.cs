using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Infrastructure;
using MediatR;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Queries.Get
{
    public class GetCustomerCardHandler : IRequestHandler<GetCustomerCardQuery, BaseDto<CustomerCardInput>>
    {
        private readonly ProjectContext _context;

        public GetCustomerCardHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerCardInput>> Handle(GetCustomerCardQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.customercards.FindAsync(request.id);
            if (result == null)
            {
                return new BaseDto<CustomerCardInput>
                {
                    Message = "Failed retrieve customer card payment data",
                    Status = false,
                    Data = null
                };
            }
            else
            {
                return new BaseDto<CustomerCardInput>
                {
                    Message = "Success retrieve customer card payment data",
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
        }
    }
}
