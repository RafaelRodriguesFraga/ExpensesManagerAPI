using DotnetBaseKit.Components.Application.Base;
using ExpensesManager.Application.ViewModels.User;

namespace ExpensesManager.Application.Services.Auth
{
    public interface IAuthServiceApplication : IBaseServiceApplication
    {
        Task<UserViewModel> GetByEmaillAsync(string email);
        Task ResetPasswordAsync(string email, string newPassword);
    }
}