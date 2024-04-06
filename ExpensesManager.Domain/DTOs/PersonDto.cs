using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Domain.Dtos.Base;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.DTOs
{
    public class PersonDto : BaseDto
    {

        public string Name { get; set; } = string.Empty;
        public Guid UserId {get; set;}
        public override void Validate()
        {
            
        }

       
    }
}