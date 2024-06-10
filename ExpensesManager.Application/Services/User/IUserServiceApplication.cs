using DotnetBaseKit.Components.Application.Base;
using ExpensesManager.Application.ViewModels.Login;
using ExpensesManager.Application.ViewModels.User;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Services.User
{
    public interface IUserServiceApplication : IBaseServiceApplication
    {
        Task<UserViewModel> AuthenticateAsync(LoginRequestViewModel loginViewModel);
        Task CreateAsync(UserRequestDto userRequestDto);
    }
}