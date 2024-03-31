using DotnetBoilerplate.Components.Application.Base;
using expensesManager.Application.Services;
using ExpensesManager.Application.ViewModels;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Services.Interfaces
{
    public interface IUserServiceApplication : IBaseServiceApplication
    {
        Task CreateUserAsync(UserRequestDto userRequestDto);
    }
}