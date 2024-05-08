using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.ValueObjects;

namespace Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(DataSchemaConstants.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(DataSchemaConstants.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasConversion(
            e => e.Value,
            value => new Email(value))
                    .HasMaxLength(DataSchemaConstants.EmailMaxLength)
                    .IsRequired();

        builder.HasIndex(x => x.Email)
                    .IsUnique();

        builder.Property(x => x.BirthDate)
                    .IsRequired();

        builder.Property(x => x.GitHubUsername)
            .HasMaxLength(DataSchemaConstants.UsernameMaxLength)
            .IsRequired();

        builder.HasIndex(x => x.GitHubUsername)
                    .IsUnique();
    }
}
