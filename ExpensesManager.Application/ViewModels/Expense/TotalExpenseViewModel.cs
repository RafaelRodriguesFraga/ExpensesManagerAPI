using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.ViewModels.Expense;

public class TotalExpenseViewModel
{
    public string InvoiceMonth { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    
}