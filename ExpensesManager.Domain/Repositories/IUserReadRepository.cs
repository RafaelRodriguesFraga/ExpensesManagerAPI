using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IUserReadRepository : IBaseReadRepository<User>
    {
        Task<User> GetByEmaillAsync(string email);
    }
}