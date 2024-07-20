using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Application.Pagination;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Services.Person
{
    public interface IPersonServiceApplication : IBaseServiceApplication
    {
        Task CreateAsync(PersonDto person);
        Task<PersonViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<PersonViewModel>> GetByNameAsync(string name);
        Task<IEnumerable<PersonViewModel>> GetAllAsync();
        Task<PaginationResponse<PersonViewModel>> GetAllPaginatedAsync(Guid id, int page, int quantityPerPage);
    }


}