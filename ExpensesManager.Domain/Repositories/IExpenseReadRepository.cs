using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IExpenseReadRepository : IBaseReadRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetAllAsync(Guid personId);
        Task<Dictionary<string, IEnumerable<Expense>>> GetAllGroupByPurchaseDateAsync(Guid personId, string invoiceMonth);
        Task<IEnumerable<TotalExpenseDto>> CalculateTotalAsync(Guid personId);
        Task<IEnumerable<TotalExpenseDto>> CalculateTotalByCreditCardNameAsync(string creditCardName, Guid personId);
        Task<IEnumerable<Expense>> GetByCreditCardNameAsync(string credtCardName);
        Task<IEnumerable<Expense>> GetByInvoiceMonthAsync(Guid invoiceMonthId);
        Task<Dictionary<string, IEnumerable<Expense>>> FindByCreditCardNameAndInvoiceMonthAsync(string credtCardName, string invoiceMonth, Guid personId);
    }
}