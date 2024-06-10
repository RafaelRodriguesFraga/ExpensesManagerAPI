using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesManager.Infra.Sql.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Ignore(entity => entity.Notifications);
        builder.Ignore(entity => entity.Valid);
        builder.Ignore(entity => entity.Invalid);

        builder.ToTable("users");
        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.Id)
                .IsRequired()            
                .HasColumnName("id");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("email");

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("password");    
    }
}