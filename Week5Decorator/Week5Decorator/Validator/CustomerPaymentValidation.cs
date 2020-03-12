﻿using System;
using FluentValidation;
using Week5Decorator.Models;

namespace Week5Decorator.Validator
{
    public class CustomerPaymentValidation : AbstractValidator<Request<CustomerCard>>
    {
        public CustomerPaymentValidation()
        {
            RuleFor(x => x.data.attributes.name_on_card).NotEmpty().WithMessage("name can't be empty")
                    .MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => Convert.ToInt32(x.data.attributes.exp_month)).NotEmpty().WithMessage("exp_month can't be empty")
                    .InclusiveBetween(1, 12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.data.attributes.exp_year).NotEmpty().WithMessage("exp_year can't be empty");
            RuleFor(x => x.data.attributes.credit_card_number).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }
    }
}