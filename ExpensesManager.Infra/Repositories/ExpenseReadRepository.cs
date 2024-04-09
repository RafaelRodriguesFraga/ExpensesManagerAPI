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

        public async Task<ICollection<IGrouping<DateTime, Expense>>> GetAllGroupByDateAsync()
        {
            return await Set
                .AsNoTracking()
                .Include(e => e.Person)
                .GroupBy(e => e.PurchaseDate.Date)
                .ToListAsync();
        }

        public async Task<ICollection<Expense>> GetByCredtCardNameAsync(string credtCardName)
        {
            return await Set
                .AsNoTracking()
                .Include(e => e.Person)
                .Where(e => e.CreditCardName == credtCardName)
                .ToListAsync();
        }

        public async Task<ICollection<Expense>> GetByInvoiceMonthAsync(string invoicemonth)
        {
            return await Set
                .AsNoTracking()
                .Include(e => e.Person)
                .Where(e => e.InvoiceMonth == invoicemonth)
                .ToListAsync();
        }
    }
}

