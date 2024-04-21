using DotnetBaseKit.Components.Application.Base;
using expensesManager.Application.Services;
using ExpensesManager.Application.ViewModels.User;

namespace ExpensesManager.Application.Services
{
    public interface ITokenServiceApplication : IBaseServiceApplication
    {
        TokenViewModel GenerateTokenAsync(UserViewModel userViewModel);
    }   
}