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
            new InvoiceMonth(new Guid("f4371cca-b3e9-49d6-aacf-c1b99bb63caa"), "Janeiro", 01),
            new InvoiceMonth(new Guid("cf143b5b-d705-4e46-b88c-8c5aa59fc9bc"), "Fevereiro", 02),
            new InvoiceMonth(new Guid("58a0cfe2-0a5e-42cd-a2a7-1515831b068b"), "Marco", 03),
            new InvoiceMonth(new Guid("498732b2-31ae-410b-9ce0-c436d31be794"), "Abril", 04),
            new InvoiceMonth(new Guid("0325e053-cbcc-492b-b268-f7bcbd0fbacc"), "Maio", 05),
            new InvoiceMonth(new Guid("4605c82b-4ef1-40a1-baaa-4646c4bb4dff"), "Junho", 06),
            new InvoiceMonth(new Guid("42caa6f7-8fee-479a-ad6b-89fc85f89e6b"), "Julho", 07),
            new InvoiceMonth(new Guid("eec7fa31-e1d7-49a8-a179-23900b7ff6af"), "Agosto", 08),
            new InvoiceMonth(new Guid("253c382a-d5d4-4a0f-97d1-7bc582795caf"), "Setembro", 09),
            new InvoiceMonth(new Guid("3176f263-02e6-40ae-a0d8-8bb770c5d581"), "Outubro", 10),
            new InvoiceMonth(new Guid("f0509c30-2311-4209-a57f-b512b3b51d93"), "Novembro", 11),
            new InvoiceMonth(new Guid("ac9fa14b-38c4-4c4c-a614-162093942e36"), "Dezembro", 12)
        );
    }
}