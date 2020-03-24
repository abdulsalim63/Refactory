using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentServices.Application.Models;
using PaymentServices.Infrastructure;

namespace PaymentServices.Application.UseCases.Payments //.Command.MidtransPush
{
    public class PushMidtransCommandHandler : IRequestHandler<PushMidtransCommand, BaseDto<Payment_Output>>
    {
        private readonly PaymentContext _context;

        public PushMidtransCommandHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Payment_Output>> Handle(PushMidtransCommand request, CancellationToken cancellationToken)
        {
            var some_id = 0;

            var ordersData = await _context.orders.FindAsync(some_id);

            Publisher.Send(some_id.ToString(), "push");

            return new BaseDto<Payment_Output>
            {
                message = "Success",
                success = true,
                data = null
            };
        }
    }
}
