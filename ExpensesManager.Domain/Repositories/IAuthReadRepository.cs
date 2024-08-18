using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IAuthReadRepository : IBaseReadRepository<User>
    {
        Task<User> GetByEmaillAsync(string email);
    }
}