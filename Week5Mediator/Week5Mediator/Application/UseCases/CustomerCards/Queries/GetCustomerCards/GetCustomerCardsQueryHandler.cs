using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.CustomerCards.Models;

namespace Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCards
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerCardsQuery, GetCustomerCardsDto>
    {
        private readonly IBlogContext _context;

        public GetCustomerQueryHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerCardsDto> Handle(GetCustomerCardsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.customerCards.ToListAsync();

            return new GetCustomerCardsDto
            {
                Message = "Success retrieve customer data",
                Success = true,
                Data = result.Select(s => new CustomerCardsData {
                    customer_id = s.customer_id,
                    name_on_card = s.name_on_card,
                    exp_month = s.exp_month,
                    exp_year = s.exp_year,
                    postal_code = s.postal_code,
                    credit_card_number = s.credit_card_number
                }).ToList()
            };
        }
    }
}
