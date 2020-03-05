using System;
using FluentValidation;

namespace Week5Mediator.Application.UseCases.CustomerCards.Command.DeleteCustomerCard
{
    public class DeleteCustomerCardCommandValidation : AbstractValidator<DeleteCustomerCardCommand>
    {
        public DeleteCustomerCardCommandValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}
