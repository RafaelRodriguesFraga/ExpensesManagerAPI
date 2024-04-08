using DotnetBaseKit.Components.Application.Base;
using expensesManager.Application.Services;
using ExpensesManager.Application.ViewModels;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Services.User
{
    public interface IUserServiceApplication : IBaseServiceApplication
    {
        Task CreateAsync(UserRequestDto userRequestDto);
    }
}