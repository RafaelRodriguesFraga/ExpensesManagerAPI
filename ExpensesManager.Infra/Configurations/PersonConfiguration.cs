using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesManager.Infra.Sql.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Ignore(entity => entity.Notifications);
        builder.Ignore(entity => entity.Valid);
        builder.Ignore(entity => entity.Invalid);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .IsRequired()            
                .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(x => x.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

          builder.Property(x => x.UserId)                       
                .IsRequired()
                .HasColumnName("user_id");

        builder.HasOne(x => x.User)
            .WithMany(x => x.People)
            .HasForeignKey(people => people.UserId)
            .HasConstraintName("user_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("people");
    }
}