using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Application.Base;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Services.Person
{
    public interface IPersonServiceApplication : IBaseServiceApplication
    {
        Task AddPersonAsync(PersonDto person);
        Task<PersonViewModel> GetPersonByIdAsync(Guid id);
        Task<PersonViewModel> GetPersonByNameAsync(string name);
        Task<IEnumerable<PersonViewModel>> GetAllAsync();
    }

   
}