using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Username)
        .IsRequired()
        .HasMaxLength(200);

        builder.HasIndex(p => new {
            p.Username,
            p.Email
        }).HasDatabaseName("IX_MyIndex")
        .IsUnique();

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(200);

        builder
        .HasMany(p => p.Roles)
        .WithMany(p => p.Users)
        .UsingEntity<RoleUser>(
            j => j.HasOne(pt => pt.Role)
                .WithMany(t => t.RolesUsers)
                .HasForeignKey(pt => pt.RoleId),
            j => j.HasOne(pt => pt.User)
                .WithMany(t => t.RolesUsers)
                .HasForeignKey(pt => pt.UserId),
            j =>
            {
                j.HasKey(t => new { t.RoleId, t.UserId});
            }
        );
    }
}