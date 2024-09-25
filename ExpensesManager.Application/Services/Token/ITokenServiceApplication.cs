using DotnetBaseKit.Components.Application.Base;
using expensesManager.Application.Services;
using ExpensesManager.Application.ViewModels.User;
using System.Security.Claims;

namespace ExpensesManager.Application.Services
{
    public interface ITokenServiceApplication : IBaseServiceApplication
    {
        TokenViewModel GenerateTokenAsync(UserViewModel userViewModel);
        string GenerateToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        void SaveRefreshToken(string username, string refreshToken);
        string GetRefreshToken(string username);
        void DeleteRefreshToken(string username, string refreshToken);
    }   
}