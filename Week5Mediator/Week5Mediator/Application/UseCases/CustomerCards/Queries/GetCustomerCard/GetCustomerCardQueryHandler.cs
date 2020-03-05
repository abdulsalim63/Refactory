using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.CustomerCards.Models;

namespace Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCard
{
    public class GetCustomerCardQueryHandler : IRequestHandler<GetCustomerCardQuery, GetCustomerCardDto>
    {
        private readonly IBlogContext _context;

        public GetCustomerCardQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerCardDto> Handle(GetCustomerCardQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.customerCards.FirstOrDefaultAsync(x => x.id == request.id);

            return new GetCustomerCardDto
            {
                Message = "Success retrieve customer data",
                Success = true,
                Data = new CustomerCardsData
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
