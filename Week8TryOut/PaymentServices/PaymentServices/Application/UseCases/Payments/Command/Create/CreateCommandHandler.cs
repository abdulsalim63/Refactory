using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using PaymentServices.Application.Models;
using PaymentServices.Infrastructure;
using PaymentServices.Domain.Entities;
using RestSharp;

namespace PaymentServices.Application.UseCases.Payments //.Command.Create
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, BaseDto<Payment_Input>>
    {
        private readonly PaymentContext _context;

        public CreatePaymentCommandHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Payment_Input>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var data = request.data.attributes;

            var paymentData = BankPayment.payment(data);

            _context.payments.Add(paymentData);
            await _context.SaveChangesAsync(cancellationToken);

            var ordersData = await _context.orders.FindAsync(paymentData.order_id);

            Publisher.Send(ordersData.user_id.ToString(), "email");

            return new BaseDto<Payment_Input>
            {
                message = "Success Add Payment Data",
                success = true,
                data = request.data.attributes
            };
        }
    }
}
