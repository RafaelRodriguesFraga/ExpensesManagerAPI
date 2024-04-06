using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Infra.Repositories
{
    public class PersonWriteRepository : BaseWriteRepository<Person>, IPersonWriteRepository
    {
        public PersonWriteRepository(BaseContext context) : base(context)
        {
        }
    }
}