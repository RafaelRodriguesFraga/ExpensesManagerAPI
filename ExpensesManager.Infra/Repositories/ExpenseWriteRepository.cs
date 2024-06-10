using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Infra.Repositories
{
    public class ExpenseWriteRepository : BaseWriteRepository<Expense>, IExpenseWriteRepository
    {
        public ExpenseWriteRepository(BaseContext context) : base(context)
        {
        }
    }
}