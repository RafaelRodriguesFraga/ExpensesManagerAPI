using DotnetBaseKit.Components.Application.Base;
using ExpensesManager.Application.ViewModels.Expense;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Services.Expense
{
    public interface IExpenseServiceApplication : IBaseServiceApplication
    {
        Task CreateAsync(ExpenseDto expenseDto);
        Task<IEnumerable<ExpenseViewModel>> GetAllAsync(Guid personId);
        Task<Dictionary<string, IEnumerable<ExpenseGroupByPurchaseDateViewModel>>> GetAllGroupByPurchaseDateAsync(Guid personId, string invoiceMonth);
        Task<IEnumerable<TotalExpenseViewModel>> GetTotalByMonth(Guid personId);
    }
}