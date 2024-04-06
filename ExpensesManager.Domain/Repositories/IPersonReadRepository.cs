
using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IPersonReadRepository : IBaseReadRepository<Person>
    {
        Task<Person> GetByNameAsync(string name);
        
    }
}