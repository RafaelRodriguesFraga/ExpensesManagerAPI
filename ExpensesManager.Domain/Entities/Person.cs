using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Domain.Sql.Entities.Base;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Domain.Entities
{
    public class Person : BaseEntity
    {
        public Person(string name, Guid userId)
        {
            Name = name;
            UserId = userId;

        }
        public string Name { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public static implicit operator Person(PersonDto personDto)
        {
            return new Person(personDto.Name, personDto.UserId);
        }

        public override void Validate()
        {

        }
    }
}