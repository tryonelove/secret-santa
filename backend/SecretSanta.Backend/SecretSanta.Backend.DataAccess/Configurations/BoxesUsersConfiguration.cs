using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecretSanta.Backend.DomainModel;

namespace SecretSanta.Backend.DataAccess.Configurations;

public class BoxesUsersConfiguration : IEntityTypeConfiguration<BoxesUsers>
{
    public void Configure(EntityTypeBuilder<BoxesUsers> builder)
    {
        builder.HasKey(bu => new { bu.UserId, bu.BoxId });

        builder.HasOne(bu => bu.User)
            .WithMany(u => u.BoxesUsers)
            .HasForeignKey(bu => bu.UserId);

        builder.HasOne(bu => bu.Box)
            .WithMany(b => b.BoxesUsers)
            .HasForeignKey(bu => bu.BoxId);
    }
}