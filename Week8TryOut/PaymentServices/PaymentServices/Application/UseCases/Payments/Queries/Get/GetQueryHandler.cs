using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using PaymentServices.Application.Models;
using PaymentServices.Infrastructure;

namespace PaymentServices.Application.UseCases.Payments //.Queries.Get
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, BaseDto<Payment_Output>>
    {
        private readonly PaymentContext _context;

        public GetPaymentQueryHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Payment_Output>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new BaseDto<Payment_Output>
                {
                    message = "Success Retrieve Payment Data",
                    success = true,
                    data = await _context.payments.Where(x => x.id == request.id).Select(s => new Payment_Output
                    {
                        order_id = s.order_id,
                        transaction_id = s.transaction_id,
                        payment_type = s.payment_type,
                        gross_amount = Convert.ToInt64(s.gross_amount),
                        transaction_time = s.transaction_time,
                        transaction_status = s.transaction_status
                    }).FirstAsync()
                };
            }
            catch(Exception)
            {
                return new BaseDto<Payment_Output>
                {
                    message = "Failed Retrieve Payment Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
