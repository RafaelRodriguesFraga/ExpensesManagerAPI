using ExpensesManager.Domain.DTOs;
using ExpensesManager.Shared.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace ExpensesManager.Domain.Validations
{
    public class UserRequestContract : AbstractValidator<UserRequestDto>
    {
        private readonly IStringLocalizer _localizer;

        public UserRequestContract()
        {
            _localizer = LocalizerService.GetLocalizer("Localization.Messages", typeof(Messages).Assembly.GetName().Name!);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(_localizer["EmailCannotBeEmpty"]);

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage(_localizer["InvalidEmailFormat"]);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(_localizer["PasswordCannotBeEmpty"]);

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .When(x => x.Password.Length < 6)
                .WithMessage(_localizer["PasswordMustBeSixCharactersLong"]);

            RuleFor(x => x.ConfirmPassword)
                .NotEqual(x => x.Password)
                .When(x => x.ConfirmPassword != x.ConfirmPassword)
                .WithMessage(_localizer["PasswordDoesNotMatch"]);
        }
    }
}
