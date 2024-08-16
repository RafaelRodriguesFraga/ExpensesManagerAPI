namespace ExpensesManager.Domain.DTOs
{
    public class MonthlyTotalExpenseReportDto
    {
        public decimal TotalInvoice { get; set; }
        public Dictionary<string, decimal> CardTotals { get; set; } = new Dictionary<string, decimal>();
    }
}