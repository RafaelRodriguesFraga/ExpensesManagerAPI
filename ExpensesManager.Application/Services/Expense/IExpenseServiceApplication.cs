using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Application.Base;
using ExpensesManager.Application.ViewModels.Expense;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Services.Expense
{
    public interface IExpenseServiceApplication : IBaseServiceApplication
    {
        Task CreateAsync(ExpenseDto expenseDto);
        Task<IEnumerable<ExpenseViewModel>> GetAllAsync(Guid personId);
        Task<Dictionary<string, IEnumerable<ExpenseViewModel>>> GetAllGroupByPurchaseDateAsync(Guid personId, Guid invoiceMonthId);

    }
}