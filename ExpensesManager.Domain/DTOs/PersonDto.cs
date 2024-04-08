using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Domain.Dtos.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Validations;

namespace ExpensesManager.Domain.DTOs
{
    public class PersonDto : BaseDto
    {

        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public override void Validate()
        {
            var validation = new PersonDtoContract();
            var validationResult = validation.Validate(this);

            AddNotifications(validationResult);
        }
    }
}