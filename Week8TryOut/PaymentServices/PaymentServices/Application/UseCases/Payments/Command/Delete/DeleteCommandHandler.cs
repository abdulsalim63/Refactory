using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentServices.Application.Models;
using PaymentServices.Infrastructure;

namespace PaymentServices.Application.UseCases.Payments.Command.Delete
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, BaseDto<Payment_Output>>
    {
        private readonly PaymentContext _context;

        public DeletePaymentCommandHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Payment_Output>> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.payments.FindAsync(request.id);

                _context.payments.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<Payment_Output>
                {
                    message = "Success Delete Payment Data",
                    success = true,
                    data = new Payment_Output
                    {
                        order_id = data.order_id,
                        transaction_id = data.transaction_id,
                        payment_type = data.payment_type,
                        gross_amount = Convert.ToInt64(data.gross_amount),
                        transaction_time = data.transaction_time,
                        transaction_status = data.transaction_status
                    }
                };
            }
            catch (Exception)
            {
                return new BaseDto<Payment_Output>
                {
                    message = "Failed Delete Payment Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
