using System.Text.Json.Serialization;
using DotnetBaseKit.Components.Domain.Dtos.Base;
using ExpensesManager.Domain.Validations;

namespace ExpensesManager.Domain.DTOs
{
    public class ExpenseDto : BaseDto
    {
        public string CreditCardName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid InvoiceMonthId { get; set; }
        public bool IsInstallment { get; set; }
        public int TotalInstallments { get; set; }

        [JsonIgnore]
        public decimal InstallmentPrice { get; set; }

        [JsonIgnore]
        public int CurrentInstallment { get; set; }
        
        [JsonIgnore]
        public string InstallmentInfo { get; set; } = string.Empty;
        public Guid PersonId { get; set; }

        public override void Validate()
        {
            var validation = new ExpenseDtoContract();
            var validationResult = validation.Validate(this);

            AddNotifications(validationResult);
        }
    }
}