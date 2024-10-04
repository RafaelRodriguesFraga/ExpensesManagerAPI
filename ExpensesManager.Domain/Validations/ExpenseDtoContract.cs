using ExpensesManager.Domain.DTOs;
using ExpensesManager.Shared.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace ExpensesManager.Domain.Validations
{
    public class ExpenseDtoContract : AbstractValidator<ExpenseDto>
    {
        private readonly IStringLocalizer _localizer;

        public ExpenseDtoContract()
        {          

            RuleFor(x => x.CreditCardName)
                .NotEmpty()
                .WithMessage(_localizer["CreditCardNameCannotBeEmpty"]);

            RuleFor(x => x.Price)
              .GreaterThan(0)
              .WithMessage(_localizer["PriceMustBeGreaterThanZero"]);  

            RuleFor(x => x.InvoiceMonthId)
                .NotEmpty()
                .WithMessage(_localizer["InvoiceMonthCannotBeEmpty"]);

            RuleFor(x => x.PersonId)
              .NotEmpty()
              .WithMessage(_localizer["PersonIdCannotBeEmpty"]);
        }
    }
}
