using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder.Property(x => x.CreditCardName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)                
                .IsRequired();
            
            builder.Property(x => x.Price)                       
                .IsRequired();
            
            builder.Property(x => x.PurchaseDate)                       
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder.Property(x => x.InvoiceMonth)                       
                .IsRequired()
                .HasMaxLength(10);
              
            builder.Property(x => x.IsInstallment)                       
                .IsRequired();

            builder.Property(x => x.Paid)                       
                .IsRequired();

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Expenses)
                .HasForeignKey(expense => expense.PersonId);
        }
    }
}