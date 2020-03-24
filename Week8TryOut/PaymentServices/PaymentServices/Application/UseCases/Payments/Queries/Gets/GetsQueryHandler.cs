using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using PaymentServices.Application.Models;
using PaymentServices.Infrastructure;

namespace PaymentServices.Application.UseCases.Payments //.Queries.Gets
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, BaseDto<List<Payment_Output>>>
    {
        private readonly PaymentContext _context;

        public GetPaymentsQueryHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<List<Payment_Output>>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            return new BaseDto<List<Payment_Output>>
            {
                message = "Success Retrieve Payment Datas",
                success = true,
                data = await _context.payments.Select(s => new Payment_Output
                {
                    order_id = s.order_id,
                    transaction_id = s.transaction_id,
                    payment_type = s.payment_type,
                    gross_amount = Convert.ToInt32(s.gross_amount),
                    transaction_time = s.transaction_time,
                    transaction_status = s.transaction_status
                }).ToListAsync()
            };
        }
    }
}
