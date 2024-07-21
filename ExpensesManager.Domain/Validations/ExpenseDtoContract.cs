using ExpensesManager.Domain.DTOs;
using FluentValidation;

namespace ExpensesManager.Domain.Validations
{
    public class ExpenseDtoContract : AbstractValidator<ExpenseDto>
    {
        public ExpenseDtoContract()
        {
            RuleFor(x => x.CreditCardName)
                .NotEmpty()
                .WithMessage("Credit card cannot be empty.");

            RuleFor(x => x.Price)
              .GreaterThan(0)
              .WithMessage("The price must be greater than 0.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0.01m)
                .WithMessage("The price must be equal to or greater than 0.01.");

            RuleFor(x => x.PurchaseDate)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("The purchase date must be after the minimum date.");

            RuleFor(x => x.InvoiceMonthId)
                .NotEmpty()
                .WithMessage("Invoice month id cannot be empty.");

            RuleFor(x => x.PersonId)
              .NotEmpty()
              .WithMessage("PersonId cannot be empty.");
        }
    }
}
