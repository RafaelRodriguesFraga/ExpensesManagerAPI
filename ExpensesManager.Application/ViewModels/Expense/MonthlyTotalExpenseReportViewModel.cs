namespace ExpensesManager.Application.ViewModels.Expense;

public class MonthlyTotalExpenseReportViewModel
{
    public decimal TotalInvoice { get; set; }
    public Dictionary<string, decimal> CardTotals { get; set; } = new Dictionary<string, decimal>();
}
