using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.ValueObjects
{
    public class PurchaseDetails
    {
        
        public PurchaseDetails(string description, decimal price, DateTime purchaseDate, string invoiceMonth, bool isInstallment)
        {
            Description = description;
            Price = price;
            PurchaseDate = purchaseDate;
            InvoiceMonth = invoiceMonth;
            IsInstallment = isInstallment;
        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public string InvoiceMonth { get; private set; }
        public bool IsInstallment { get; private set; }
    }
}