using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Application.ViewModels.Person
{
    public class PersonViewModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid UserId {get;set;}

        public static implicit operator PersonViewModel(Domain.Entities.Person person)
        {
            return new PersonViewModel
            {
                Id = person.Id,
                Name = person.Name,
                UserId = person.UserId
            };
        }
    }

}