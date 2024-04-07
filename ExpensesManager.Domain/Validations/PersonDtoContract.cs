using ExpensesManager.Domain.DTOs;
using FluentValidation;

namespace ExpensesManager.Domain.Validations
{
    public class PersonDtoContract : AbstractValidator<PersonDto>
    {
        public PersonDtoContract()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.");

              RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId cannot be empty.");          
        }
    }
}
