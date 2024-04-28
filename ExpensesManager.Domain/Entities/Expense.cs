using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Domain.Sql.Entities.Base;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public Expense() { }

        public Expense(string creditCardName, string description, decimal price, DateTime purchaseDate, string invoiceMonth, bool isInstallment, bool paid)
        {
            CreditCardName = creditCardName;
            Description = description;
            Price = price;
            PurchaseDate = purchaseDate;
            InvoiceMonth = invoiceMonth;
            IsInstallment = isInstallment;
            Paid = paid;
        }

        public string CreditCardName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public string InvoiceMonth { get; private set; }
        public bool IsInstallment { get; private set; }
        public bool Paid { get; private set; }
        public Guid PersonId { get; private set; }
        public Person Person { get; private set; }

        public static implicit operator Expense(ExpenseDto expenseDto)
        {
            return new Expense(
                 expenseDto.CreditCardName,
                 expenseDto.Description,
                 expenseDto.Price,
                 expenseDto.PurchaseDate,
                 expenseDto.InvoiceMonth,
                 expenseDto.IsInstallment,
                 expenseDto.Paid
                 );
        }

        public override void Validate()
        {

        }
    }
}