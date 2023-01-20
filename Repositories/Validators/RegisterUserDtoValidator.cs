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
                .EmailAddress()
                .WithMessage("Adres email nie może być pusty!");

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .WithMessage("Hasło powinno zawierać minimum 6 znaków!");

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password)
                .WithMessage("Hasła się nie zgadzają!");

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
