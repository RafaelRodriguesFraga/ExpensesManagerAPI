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
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamp without time zone");

        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Password)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}