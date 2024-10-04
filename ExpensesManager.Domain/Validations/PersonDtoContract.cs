﻿using ExpensesManager.Domain.DTOs;
using ExpensesManager.Shared.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace ExpensesManager.Domain.Validations
{
    public class PersonDtoContract : AbstractValidator<PersonDto>
    {
        private readonly IStringLocalizer _localizer;

        public PersonDtoContract()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(_localizer["NameCannotBeEmpty"]);

              RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage(_localizer["UserIdCannotBeEmpty"]);          
        }
    }
}
    