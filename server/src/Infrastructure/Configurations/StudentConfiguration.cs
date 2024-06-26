﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;
using Domain.Entities;
using Application.Consts;

namespace Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(StudentConsts.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(StudentConsts.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasConversion(
            e => e.Value,
            value => new Email(value))
                    .HasMaxLength(StudentConsts.EmailMaxLength)
                    .IsRequired();

        builder.HasIndex(x => x.Email)
                    .IsUnique();

        builder.Property(x => x.BirthDate)
                    .IsRequired();

        builder.Property(x => x.GitHubUsername)
            .HasMaxLength(StudentConsts.UsernameMaxLength)
            .IsRequired();

        builder.HasIndex(x => x.GitHubUsername)
                    .IsUnique();
    }
}
