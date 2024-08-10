namespace ExpensesManager.Application.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        public string CreditCardName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string InvoiceMonth { get; set; } = string.Empty;
        public bool IsInstallment { get; set; }
        
    }
}