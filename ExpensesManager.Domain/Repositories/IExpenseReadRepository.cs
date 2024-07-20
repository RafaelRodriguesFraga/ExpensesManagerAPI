using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IExpenseReadRepository : IBaseReadRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetAllAsync(Guid personId);
       Task<Dictionary<string, IEnumerable<Expense>>> GetAllGroupByPurchaseDateAsync(Guid personId, string invoiceMonth);
       Task CalculateTotal(Guid personId);
        Task<IEnumerable<Expense>> GetByCreditCardNameAsync(string credtCardName);
        Task<IEnumerable<Expense>> GetByInvoiceMonthAsync(string invoicemonth);
    }
}