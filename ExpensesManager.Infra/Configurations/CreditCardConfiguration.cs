using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesManager.Infra.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        
        builder.Ignore(entity => entity.Notifications);
        builder.Ignore(entity => entity.Valid);
        builder.Ignore(entity => entity.Invalid);

        builder.ToTable("credit_card");

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
        
        builder.HasData(
            new CreditCard ( "Inter Gold" ),
            new CreditCard ( "Inter Black" ),
            new CreditCard ( "Amex TGC" ),
            new CreditCard ( "XP Visa Infinite" ),
            new CreditCard ("BB Elo Mais" ),
            new CreditCard ( "C6 Bank Standard" )
        );
    }
}