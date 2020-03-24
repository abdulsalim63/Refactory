using System;
using FluentValidation;
using PaymentServices.Application.Models;

namespace PaymentServices.Application.UseCases.Payments //.Command.Create
{
    public class CreatePaymentCommandValidation : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidation()
        {
            RuleFor(x => x.data.attributes.bank).Must(x => x.ToLower() == "bni" || x.ToLower() == "bca")
                .WithMessage("Bank must be BNI or BCA");
            RuleFor(x => x.data.attributes.payment_type).Equal("bank_transfer").WithMessage("Payment Type only accept bank transfer");
            RuleFor(x => x.data.attributes.order_id).GreaterThan(0);
        }
    }
}
