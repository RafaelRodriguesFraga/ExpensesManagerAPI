using ExpensesManager.Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.Validations
{
    public class UserRequestContract : AbstractValidator<UserRequestDto>
    {
        public UserRequestContract()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Enter your email.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("The email must be in a valid format.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("The password is empty.");

            RuleFor(x => x.Password)
                .Length(8, 100)
                .WithMessage("The password must be a minimum of 8 and a maximum of 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.Password));

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("The confirmation password does not match.")
                .When(x => !string.IsNullOrEmpty(x.Password));
        }
    }
}
