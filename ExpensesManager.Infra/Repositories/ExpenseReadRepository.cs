using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Repositories
{
    public class ExpenseReadRepository : BaseReadRepository<Expense>, IExpenseReadRepository
    {
        public ExpenseReadRepository(BaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Expense>> GetAllAsync(Guid personId)
        {
            var expenses = await Set
                .AsNoTracking()
                .Include(im => im.InvoiceMonth)
                .Where(x => x.PersonId == personId)
                .ToListAsync();

            return expenses;
        }

        public async Task<Dictionary<string, IEnumerable<Expense>>> GetAllGroupByPurchaseDateAsync(Guid personId, string invoiceMonth)
        {
            var expenses = await Set
                .AsNoTracking()
                .Include(im => im.InvoiceMonth)
                .Where(x => x.InvoiceMonth.Name == invoiceMonth && x.PersonId == personId)
                .ToListAsync();

            var grouped = expenses
                .GroupBy(e => e.PurchaseDate.Date)
                .OrderByDescending(g => g.Key)
                .ToDictionary(g => g.Key.ToString("dd/MM/yyyy"), g => g.ToList().AsEnumerable());

            return grouped;
        }

        public async Task<IEnumerable<TotalExpenseDto>> CalculateTotalAsync(Guid personId)
        {
            var expenses = await Set
                .AsNoTracking()
                .Include(x => x.InvoiceMonth)
                .Where(x => x.PersonId == personId)
                .GroupBy(e => new { e.InvoiceMonth.Name, e.InvoiceMonth.Code })
                .Select(g => new TotalExpenseDto
                {
                    InvoiceMonth = g.Key.Name,
                    TotalPrice = g.Sum(e => e.IsInstallment ? e.InstallmentPrice : e.Price),
                    Code = g.Key.Code
                })
                .OrderBy(g => g.Code)
                .ToListAsync();

            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetByCreditCardNameAsync(string creditCardName)
        {
            return await Set
                .AsNoTracking()
                .Include(e => e.Person)
                .Where(e => e.CreditCardName == creditCardName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetByInvoiceMonthAsync(Guid invoiceMonthId)
        {
            return await Set
                .AsNoTracking()
                .Include(e => e.Person)
                .Where(e => e.InvoiceMonthId == invoiceMonthId)
                .ToListAsync();
        }

        public async Task<Dictionary<string, IEnumerable<Expense>>> FindByCreditCardNameAndInvoiceMonthAsync(string credtCardName, string invoiceMonth, Guid personId)
        {
            var expenses = await Set
              .AsNoTracking()
              .Include(im => im.InvoiceMonth)
              .Where(x => x.InvoiceMonth.Name == invoiceMonth
                        && x.PersonId == personId
                        && x.CreditCardName.Contains(credtCardName))
              .ToListAsync();

            var grouped = expenses
                .GroupBy(e => e.PurchaseDate.Date)
                .OrderByDescending(g => g.Key)
                .ToDictionary(g => g.Key.ToString("dd/MM/yyyy"), g => g.ToList().AsEnumerable());

            return grouped;
        }

        public Task<IEnumerable<TotalExpenseDto>> CalculateTotalByCreditCardNameAsync(string creditCardName, Guid personId)
        {
            throw new NotImplementedException();
        }
    }
}