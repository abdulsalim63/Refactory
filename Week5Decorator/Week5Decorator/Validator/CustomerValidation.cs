using System;
using FluentValidation;
using Week5Decorator.Models;
using Week5Decorator.Controllers;

namespace Week5Decorator.Validator
{
    public class CustomerValidator : AbstractValidator<Request<Customer>>
    {
        public CustomerValidator()
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
