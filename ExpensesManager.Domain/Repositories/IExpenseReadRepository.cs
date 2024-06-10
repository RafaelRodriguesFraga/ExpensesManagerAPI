using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IExpenseReadRepository : IBaseReadRepository<Expense>
    {
       Task<Dictionary<string, IEnumerable<Expense>>> GetAllGroupByPurchaseDateAsync(string invoiceMonth);
        Task<IEnumerable<Expense>> GetByCreditCardNameAsync(string credtCardName);
        Task<IEnumerable<Expense>> GetByInvoiceMonthAsync(string invoicemonth);
    }
}