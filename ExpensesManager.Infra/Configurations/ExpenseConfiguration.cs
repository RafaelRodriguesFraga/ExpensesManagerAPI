using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesManager.Infra.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Ignore(entity => entity.Notifications);
            builder.Ignore(entity => entity.Valid);
            builder.Ignore(entity => entity.Invalid);

            builder.ToTable("expenses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            
            builder.Property(x => x.CreditCardName)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("credit_card_name");
            
            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description");
            
            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("price");
            
            builder.Property(x => x.PurchaseDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone")
                .HasColumnName("purchase_date");

            builder.Property(x => x.InvoiceMonthId)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("invoice_month_id");

            builder.Property(x => x.IsInstallment)
                .IsRequired()
                .HasColumnName("is_installment");

            builder.Property(x => x.PersonId)
                .IsRequired()
                .HasColumnName("person_id");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Expenses)
                .HasForeignKey(expense => expense.PersonId)
                .HasConstraintName("person_id");

            builder.HasOne(x => x.InvoiceMonth)
                .WithMany(x => x.Expenses)
                .HasForeignKey(expense => expense.InvoiceMonthId)
                .HasConstraintName("invoice_month_id");
        }
    }
}