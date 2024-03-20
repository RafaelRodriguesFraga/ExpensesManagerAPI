using DotnetBoilerplate.Components.Infra.Sql.Context.Base;
using DotnetBoilerplate.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Infra.Repositories
{
    public class TestWriteRepository : BaseWriteRepository<Test>, ITestWriteRepository
    {
        public TestWriteRepository(BaseContext context) : base(context)
        {
        }
    }
}