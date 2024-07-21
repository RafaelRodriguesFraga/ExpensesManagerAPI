using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesManager.Infra.Configurations;

public class InvoiceMonthConfiguration : IEntityTypeConfiguration<InvoiceMonth>
{
    public void Configure(EntityTypeBuilder<InvoiceMonth> builder)
    {

        builder.Ignore(entity => entity.Notifications);
        builder.Ignore(entity => entity.Valid);
        builder.Ignore(entity => entity.Invalid);

        builder.ToTable("invoice_months");

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(x => x.Code)
            .IsRequired()
            .HasColumnName("code");

        builder.HasData(
            new InvoiceMonth("Janeio", 01),
            new InvoiceMonth("Fevereiro", 02),
            new InvoiceMonth("Marco", 03),
            new InvoiceMonth("Abril", 04),
            new InvoiceMonth("Maio", 05),
            new InvoiceMonth("Junho", 06),
            new InvoiceMonth("Julho", 07),
            new InvoiceMonth("Agosto", 08),
            new InvoiceMonth("Setembro", 09),
            new InvoiceMonth("Outubro", 10),
            new InvoiceMonth("Novembro", 11),
            new InvoiceMonth("Dezembro", 12)
        );
    }
}