using Azure;
using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
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
                .Where(x => x.PersonId == personId)
                .ToListAsync();

            return expenses;
        }

        public async Task<Dictionary<string, IEnumerable<Expense>>> GetAllGroupByPurchaseDateAsync(Guid personId, string invoiceMonth)
        {
            var expenses = await Set
                .AsNoTracking()    
                .Where(x => x.InvoiceMonth == invoiceMonth && x.PersonId == personId)           
                .ToListAsync();

            var grouped = expenses
                .GroupBy(e => e.PurchaseDate.Date)
                .ToDictionary(g => g.Key.ToString("dd/MM/yyyy"), g => g.ToList().AsEnumerable());

            return grouped;
        }

        public Task CalculateTotal(Guid personId)
        {
            var expenses = Set
                .AsNoTracking()
                .Where(x => x.PersonId == personId)
                .GroupBy(x => x.InvoiceMonth)
                .Select(g => new
                {
                    InvoiceMonth = g.Key,
                    TotalPrice = g.Sum(e => e.Price)
                })
                .ToListAsync();
                
            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetByCreditCardNameAsync(string credtCardName)
        {
            return await Set
                .AsNoTracking()
                .Include(e => e.Person)
                .Where(e => e.CreditCardName == credtCardName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetByInvoiceMonthAsync(string invoicemonth)
        {
            return await Set
                .AsNoTracking()
                .Include(e => e.Person)
                .Where(e => e.InvoiceMonth == invoicemonth)
                .ToListAsync();
        }
    }
}