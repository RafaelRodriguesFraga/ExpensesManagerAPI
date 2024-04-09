using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Domain.Dtos.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Validations;

namespace ExpensesManager.Domain.DTOs
{
    public class ExpenseDto : BaseDto
    {
        public string CreditCardName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string InvoiceMonth { get; set; } = string.Empty;
        public bool IsInstallment { get; set; }
        public bool Paid { get; set; }
        public Guid PersonId { get; set; }
        public override void Validate()
        {
            var validation = new ExpenseDtoContract();
            var validationResult = validation.Validate(this);

            AddNotifications(validationResult);
        }
    }
}