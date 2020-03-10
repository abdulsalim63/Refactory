using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerAndCustomerCard.Application.UseCases.CustomerCards //.Queries.Gets
{
    public class GetCustomerCardsHandler : IRequestHandler<GetCustomerCardsQuery, BaseDto<IList<CustomerCardInput>>>
    {
        private readonly ProjectContext _context;

        public GetCustomerCardsHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<IList<CustomerCardInput>>> Handle(GetCustomerCardsQuery request, CancellationToken cancellationToken) =>
            new BaseDto<IList<CustomerCardInput>>
            {
                Message = "Success retrieve customer card payment datas",
                Status = true,
                Data = await _context.customercards.OrderBy(x => x.id).Select(s => new CustomerCardInput
                {
                    customer_id = s.customer_id,
                    name_on_card = s.name_on_card,
                    exp_month = s.exp_month,
                    exp_year = s.exp_year,
                    postal_code = s.postal_code,
                    credit_card_number = s.credit_card_number
                }).ToListAsync()
            };
    }
}
