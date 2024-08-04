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

        public Expense(string creditCardName, string description, decimal price, DateTime purchaseDate, Guid invoiceMonthId, bool isInstallment, Guid personGuid)
        {
            CreditCardName = creditCardName;
            Description = description;
            Price = price;
            PurchaseDate = purchaseDate;
            InvoiceMonthId = invoiceMonthId;
            IsInstallment = isInstallment;
            PersonId = personGuid;
        }

        public string CreditCardName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public Guid InvoiceMonthId { get; private set; }
        public InvoiceMonth InvoiceMonth { get; private set; }
        public bool IsInstallment { get; private set; }
        public int TotalInstallments { get; private set; }
        public decimal InstallmentPrice { get; private set; }
        public int CurrentInstallment { get; private set ; }
        public string InstallmentInfo {get;private set;}
        public Guid PersonId { get; private set; }
        public Person Person { get; private set; }

        public static implicit operator Expense(ExpenseDto expenseDto)
        {
            return new Expense
            {
                CreditCardName = expenseDto.CreditCardName,
                Description = expenseDto.Description,
                Price = expenseDto.Price,
                PurchaseDate = expenseDto.PurchaseDate,
                InvoiceMonthId = expenseDto.InvoiceMonthId,
                IsInstallment = expenseDto.IsInstallment,
                TotalInstallments = expenseDto.TotalInstallments,
                InstallmentPrice = expenseDto.InstallmentPrice,
                CurrentInstallment = expenseDto.CurrentInstallment,
                InstallmentInfo = expenseDto.InstallmentInfo,
                PersonId = expenseDto.PersonId
            };
        }

        public override void Validate()
        {

        }
    }
}