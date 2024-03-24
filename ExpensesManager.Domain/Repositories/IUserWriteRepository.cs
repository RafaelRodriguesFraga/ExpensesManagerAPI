using DotnetBoilerplate.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IUserWriteRepository : IBaseWriteRepository<User>
    {
        
    }
}