namespace ExpensesManager.Domain.DTOs;

public class TotalExpenseDto
{
    public string InvoiceMonth { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public int Code { get; set; }


}