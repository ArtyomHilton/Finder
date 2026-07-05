using Finder.Common.EF;
using Finder.Identity.Domain.Entities.User;
using Finder.Identity.Domain.Entities.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finder.Identity.Infrastructure.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                x => x.Value,
                x => UserId.Create(x)
            );

        builder.Property(x => x.Login)
            .HasConversion(
                x => x.Value,
                x => Login.Create(x)
            )
            .IsRequired();
        builder.HasIndex(x => x.Login)
            .IsUnique();

        builder.Property(x => x.Password)
            .HasConversion(
                x => x.Value, 
                x => Password.Create(x)
            )
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql(DatabaseConstants.UtcNow)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdatedAt)
            .HasDefaultValueSql(DatabaseConstants.UtcNow)
            .ValueGeneratedOnAddOrUpdate();

        builder.OwnsOne(x => x.Info, builder =>
        {
            builder.ToTable(nameof(UserInfo));

            builder.Property(x => x.FirstName)
                .IsRequired();
            builder.HasIndex(x => x.FirstName);

            builder.Property(x => x.LastName)
                .IsRequired();
            builder.HasIndex(x => x.LastName);

            builder.HasIndex(x => x.Patronymic);

            builder.Property(x => x.BirthdayDate);
            builder.HasIndex(x => x.BirthdayDate);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql(DatabaseConstants.UtcNow)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql(DatabaseConstants.UtcNow)
                .ValueGeneratedOnAddOrUpdate();

            builder.WithOwner()
                .HasForeignKey("Id");
        });
    }
}
