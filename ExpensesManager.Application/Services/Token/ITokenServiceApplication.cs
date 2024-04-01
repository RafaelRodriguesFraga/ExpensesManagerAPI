using DotnetBaseKit.Components.Application.Base;
using expensesManager.Application.Services;

namespace ExpensesManager.Application.Services
{
    public interface ITokenServiceApplication : IBaseServiceApplication
    {
        TokenViewModel GenerateTokenAsync(Guid id, string email);
    }   
}