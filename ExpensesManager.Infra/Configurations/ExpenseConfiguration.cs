using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesManager.Infra.Sql.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.Ignore(entity => entity.Notifications);
        builder.Ignore(entity => entity.Valid);
        builder.Ignore(entity => entity.Invalid);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreditCardName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.PurchaseDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.Property(x => x.InvoiceMonth)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.IsInstallment)
            .IsRequired();

        builder.Property(x => x.Paid)
            .IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.Expenses)
            .HasForeignKey(exponse => exponse.PersonId);

        builder.Property(x => x.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.ToTable("expenses");
    }
}