using Domain;
using FluentValidation;
using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(DSMDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailvalidate = dbContext.Users.Any(u => u.Email == value);
                    if (emailvalidate)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.PhoneNumber)
                .Custom((value, context) =>
                {
                    var phonevalidator = dbContext.Users.Any(u => u.Identiti.PhoneNumber == value);
                    if (phonevalidator)
                    {
                        context.AddFailure("PhoneNumber", "That phone number is taken");
                    }
                });
        }
    }
}
