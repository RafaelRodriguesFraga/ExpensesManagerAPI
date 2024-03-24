using DotnetBoilerplate.Components.Infra.Sql.Context.Base;
using DotnetBoilerplate.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Infra.Repositories
{
    public class UserWriteRepository : BaseWriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(BaseContext context) : base(context)
        {
        }
    }
}