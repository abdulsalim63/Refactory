using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentServices.Application.Models;
using PaymentServices.Infrastructure;

namespace PaymentServices.Application.UseCases.Payments //.Command.Update
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, BaseDto<Payment_Input>>
    {
        private readonly PaymentContext _context;

        public UpdatePaymentCommandHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Payment_Input>> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.payments.FindAsync(request.id);
                var inputData = request.data.attributes;

                var paymentData = BankPayment.payment(inputData);

                data.payment_type = paymentData.payment_type;
                data.gross_amount = paymentData.gross_amount.ToString();
                data.order_id = paymentData.order_id;
                data.transaction_id = paymentData.transaction_id;
                data.transaction_time = paymentData.transaction_time;
                data.transaction_status = paymentData.transaction_status;
                data.updated_at = paymentData.updated_at;

                await _context.SaveChangesAsync(cancellationToken);

                var ordersData = await _context.orders.FindAsync(paymentData.order_id);

                Publisher.Send(ordersData.user_id.ToString());

                return new BaseDto<Payment_Input>
                {
                    message = "Success Update Payment Data",
                    success = true,
                    data = new Payment_Input
                    {
                        order_id = data.order_id,
                        payment_type = data.payment_type,
                        gross_amount = Convert.ToInt64(data.gross_amount),
                        bank = inputData.bank
                    }
                };
            }
            catch (Exception)
            {
                return new BaseDto<Payment_Input>
                {
                    message = "Failed Update Payment Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
