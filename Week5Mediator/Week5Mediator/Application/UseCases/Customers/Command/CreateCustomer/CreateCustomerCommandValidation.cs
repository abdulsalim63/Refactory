using System;
using FluentValidation;

namespace Week5Mediator.Application.UseCases.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(x => x.data.attributes.username).NotEmpty().WithMessage("username can't be empty")
                    .MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(x => x.data.attributes.email).NotEmpty().WithMessage("email can't be empty")
                    .EmailAddress().WithMessage("email is not valid email address");
            RuleFor(x => x.data.attributes.gender).NotEmpty().WithMessage("gender can't be empty")
                    .Must(gender => gender == "male" || gender == "female")
                    .WithMessage("gender is one of male or female");
            RuleFor(x => x.data.attributes.birthdate).NotEmpty().WithMessage("birthdate can't be empty")
                    .Must(w => Math.Floor((DateTime.UtcNow - w).TotalDays / 365.0) >= 18)
                    .WithMessage("age must be greater than 18");
        }
    }
}
