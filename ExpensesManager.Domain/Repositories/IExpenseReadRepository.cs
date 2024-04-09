
using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IExpenseReadRepository : IBaseReadRepository<Expense>
    {
        Task<ICollection<IGrouping<DateTime, Expense>>> GetAllGroupByDateAsync();
        Task<ICollection<Expense>> GetByCredtCardNameAsync(string credtCardName);
        Task<ICollection<Expense>> GetByInvoiceMonthAsync(string invoicemonth);
    }
}