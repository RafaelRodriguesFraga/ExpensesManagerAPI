using DotnetBoilerplate.Components.Infra.Sql.Context.Base;
using DotnetBoilerplate.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Infra.Repositories
{
    public class TestReadRepository : BaseReadRepository<Test>, ITestReadRepository
    {
        public TestReadRepository(BaseContext context) : base(context)
        {
        }
    }
}