using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;

namespace ExpensesManager.Infra.Repositories
{
    public class ExpenseReadRepository : BaseReadRepository<Expense>, IExpenseReadRepository
    {

        private readonly BaseContext _context;
        public ExpenseReadRepository(BaseContext context) : base(context)
        {
            _context = context;
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

        public async Task<Dictionary<string, MonthlyTotalExpenseReportDto>> GetMonthlyTotalsReportAsync(Guid personId)
        {
            var reports = new Dictionary<string, MonthlyTotalExpenseReportDto>();
            // Consulta para totais por mês
            var monthlyTotalsQuery = @"
            SELECT 
                im.name AS ""MonthName"",
                SUM(
                    CASE 
                        WHEN e.is_installment THEN e.installment_price
   						ELSE e.price
                    END
                ) AS TotalInvoice
            FROM expenses e
            JOIN invoice_months im ON im.id = e.invoice_month_id
            WHERE e.person_id = @personId
            GROUP BY im.name, im.code
            ORDER BY im.code";

            var cardTotalsQuery = @"
            SELECT 
                im.name AS MonthName,
                e.credit_card_name AS CreditCardName,
                SUM(
                    CASE 
                        WHEN e.is_installment THEN e.installment_price
	                    WHEN e.current_installment > 1 AND e.current_installment <= e.total_installments THEN e.installment_price -- Para parcelas futuras
          		        ELSE e.price
                    END
                ) AS CardTotal
            FROM expenses e
            JOIN invoice_months im ON im.id = e.invoice_month_id
            WHERE e.person_id = @personId
            GROUP BY im.name, im.code, e.credit_card_name
            ORDER BY im.code";

            using (var connection = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();

                // Comando para obter o total das faturas
                using (var command = new NpgsqlCommand(monthlyTotalsQuery, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("@personId", personId));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var monthName = reader["MonthName"].ToString();
                            var totalInvoice = Convert.ToDecimal(reader["TotalInvoice"]);

                            reports[monthName!] = new MonthlyTotalExpenseReportDto
                            {
                                TotalInvoice = totalInvoice,
                                CardTotals = new Dictionary<string, decimal>()
                            };
                        }
                    }
                }

                // Comando para obter os totais por cartão de crédito
                using (var connection2 = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await connection2.OpenAsync();

                    using (var command2 = new NpgsqlCommand(cardTotalsQuery, connection2))
                    {
                        command2.Parameters.Add(new NpgsqlParameter("@personId", personId));

                        using (var reader2 = await command2.ExecuteReaderAsync())
                        {
                            while (await reader2.ReadAsync())
                            {
                                var monthName = reader2["MonthName"].ToString();
                                var creditCardName = reader2["CreditCardName"].ToString();
                                var cardTotal = Convert.ToDecimal(reader2["CardTotal"]);

                                reports[monthName!].CardTotals[creditCardName!] = cardTotal;

                            }
                        }
                    }
                }
            }
            return reports;
        }
    }
}